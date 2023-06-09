﻿using LauncherClient.MVVM.Core;
using LauncherClient.MVVM.Model;
using LauncherClient.Net;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;

namespace LauncherClient.MVVM.ViewModel
{
    class MainViewModel
    {
        public ObservableCollection<UserModel> Users { get; set; } 
        public RelayCommand ConnectToServerCommand { get; private set; }
        public RelayCommand SendMessageCommand { get; set; }
        private Server _server;
        public string Username { get; set; }
        public string Message { get; set; }

        public MainViewModel()
        {
            Users = new ObservableCollection<UserModel>();
            _server = new Server();
            _server.connectedEvent += UserConnected;
            ConnectToServerCommand = new RelayCommand(o => _server.ConnectServer(Username),
                o => !string.IsNullOrEmpty(Username));



            SendMessageCommand = new RelayCommand(o => _server.SendMessageToServer(Message),
       o => !string.IsNullOrEmpty(Message));
        }

        private void UserConnected()
        {
            UserModel user = new UserModel
            {
                Username = _server.PacketReader.ReadMessage(),
                UID = _server.PacketReader.ReadMessage(),
            };
            //Make sure check this on the server to avoid duplications
            //Doing it from a different THREAD so use DISPATCHER
            if(!Users.Any(x => x.UID == user.UID))
            {
                Application.Current.Dispatcher.Invoke(() => Users.Add(user));
            }
        }
    }
}
