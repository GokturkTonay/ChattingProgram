using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ChatUygulamasi
{
    public partial class Form1 : Form
    {
        private UdpClient udpListener;
        private const int Port = 15000;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text))
            {
                MessageBox.Show("Lütfen bir kullanıcı adı girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ... (UdpClient ayarları aynı kalacak, port paylaşımını destekleyen kod) ...
                udpListener = new UdpClient();
                udpListener.ExclusiveAddressUse = false;
                udpListener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Port);
                udpListener.Client.Bind(localEndPoint);

                // Dinlemeyi başlat
                Task.Run(() => ListenForMessages());

                // ---- YENİ KOD ----
                // Herkese katıldığınızı bildiren bir mesaj yayınlayın
                string joinMessage = $"[{txtKullaniciAdi.Text} sohbete katıldı.]";
                byte[] data = Encoding.UTF8.GetBytes(joinMessage);
                using (UdpClient udpSender = new UdpClient())
                {
                    IPEndPoint broadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, Port);
                    udpSender.Send(data, data.Length, broadcastEndpoint);
                }
                // ---- YENİ KOD BİTİŞİ ----

                // Arayüzü güncelle
                gboxGiris.Enabled = false;
                gboxSohbet.Enabled = true;
                txtMesaj.Focus();
                this.Text = $"Lan Chat - {txtKullaniciAdi.Text}";
                lstMesajlar.Items.Add("[Sohbete hoş geldiniz...]");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task ListenForMessages()
        {
            try
            {
                while (true)
                {
                    UdpReceiveResult result = await udpListener.ReceiveAsync();
                    byte[] buffer = result.Buffer;
                    string message = Encoding.UTF8.GetString(buffer);

                    // Gelen mesajı gönderen biz miyiz?
                    // Eğer mesaj bizim kullanıcı adımızla başlıyorsa, bu bizim gönderdiğimiz
                    // mesajın yankısıdır. Zaten "Siz: ..." olarak eklediğimiz için bunu görmezden gel.
                    if (message.StartsWith($"{txtKullaniciAdi.Text}:"))
                    {
                        continue; // Döngünün bir sonraki adımına geç, bu mesajı işleme.
                    }

                    // Başkasından gelen mesajı listeye ekle.
                    UpdateChatHistory(message);
                }
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj alınırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateChatHistory(string message)
        {
            if (lstMesajlar.InvokeRequired)
            {
                // Eğer bu metot farklı bir thread'den çağrıldıysa, ana UI thread'ine yönlendir.
                lstMesajlar.Invoke(new MethodInvoker(delegate { UpdateChatHistory(message); }));
            }
            else
            {
                // Ana UI thread'indeysek, listeye mesajı ekle.
                lstMesajlar.Items.Add(message);
                // Otomatik olarak en alta kaydır
                lstMesajlar.TopIndex = lstMesajlar.Items.Count - 1;
            }
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            if (udpListener == null || string.IsNullOrWhiteSpace(txtMesaj.Text))
            {
                return;
            }

            try
            {
                // Mesaj formatı: "KullanıcıAdı: Mesaj"
                string fullMessage = $"{txtKullaniciAdi.Text}: {txtMesaj.Text}";
                byte[] data = Encoding.UTF8.GetBytes(fullMessage);

                // Kendi gönderdiğimiz mesajı "Siz:" olarak kendi listemize hemen ekleyelim
                UpdateChatHistory($"Siz: {txtMesaj.Text}");

                // Mesajı ağdaki tüm cihazlara (broadcast) gönder
                using (UdpClient udpSender = new UdpClient())
                {
                    IPEndPoint broadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, Port);
                    udpSender.Send(data, data.Length, broadcastEndpoint);
                }

                // Mesaj kutusunu temizle
                txtMesaj.Clear();
                txtMesaj.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mesaj gönderilemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMesaj_KeyDown(object sender, KeyEventArgs e)
        {
            // Eğer Enter tuşuna basıldıysa ve Shift tuşuna basılmıyorsa (alt satıra geçmek için)
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; // Enter tuşunun kendi "bip" sesini engelle
                SendMessage();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (udpListener != null)
            {
                udpListener.Close();
                udpListener = null;
            }
        }
    }
}
