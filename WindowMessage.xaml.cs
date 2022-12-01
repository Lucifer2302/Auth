using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для WindowMessage.xaml
    /// </summary>
    public partial class WindowMessage : Window
    {
        public List<ChatRoom> chatRooms = new List<ChatRoom>();

        public List<ChatRoomEmployee> chatRoomEmployees = new List<ChatRoomEmployee>();

        public WindowMessage()
        {
            InitializeComponent();
            helloGrid.DataContext = MainWindow.emplyee;
            GetRooms();
        }

        public async void GetRooms()
        {
            // Берём инфо о чатах (команатах)
            HttpResponseMessage httpResponseMessage = await MainWindow.httpClient.GetAsync("http://localhost:50203/api/Chatrooms");
            var rooms = await httpResponseMessage.Content.ReadAsStringAsync();
            // Берём инфо о пользователях в чатах (команатах)
            HttpResponseMessage responseMessage = await MainWindow.httpClient.GetAsync("http://localhost:50203/api/ChatroomEmploees");
            var emp = await responseMessage.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ChatRoomEmployee>>(emp)
                .Where(i => i.IdEmployee == MainWindow.emplyee.id).ToList();

            if (result == null)
            {

            }
            else
            {
                var temp = JsonConvert.DeserializeObject<List<ChatRoom>>(rooms).ToList();

                ChatRoomList.ItemsSource = from t in temp
                                           join r in result on t.id equals r.IdChatRoom
                                           select t;
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
