﻿using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiTreeView
{
    public class FileManagerViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<FileManager> imageNodeInfo;

        #endregion

        #region Constructor

        public FileManagerViewModel()
        {
            TreeViewSortCommand = new Command(OnTreeViewSortClicked);
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<FileManager> ImageNodeInfo
        {
            get
            {
                return imageNodeInfo;
            }
            set
            {
                this.imageNodeInfo = value;
                this.RaisedOnPropertyChanged("ImageNodeInfo");
            }
        }

        public Command TreeViewSortCommand { get; set; }

        #endregion

        #region Command method

        private void OnTreeViewSortClicked(object obj)
        {
            this.ImageNodeInfo = new ObservableCollection<FileManager>(ImageNodeInfo.OrderBy(i => i.ItemName));
        }
        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            var nodeImageInfo = new ObservableCollection<FileManager>();
            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var doc = new FileManager() { ItemName = "Documents", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_folder.png", assembly) };
            var download = new FileManager() { ItemName = "Downloads", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_folder.png", assembly) };
            var mp3 = new FileManager() { ItemName = "Music", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_folder.png", assembly) };
            var pictures = new FileManager() { ItemName = "Pictures", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_folder.png", assembly) };
            var video = new FileManager() { ItemName = "Videos", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_folder.png", assembly) };

            var pollution = new FileManager() { ItemName = "Environmental Pollution.docx", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_word.png", assembly) };
            var globalWarming = new FileManager() { ItemName = "Global Warming.ppt", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_ppt.png", assembly) };
            var sanitation = new FileManager() { ItemName = "Sanitation.docx", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_word.png", assembly) };
            var socialNetwork = new FileManager() { ItemName = "Social Network.pdf", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_pdf.png", assembly) };
            var youthEmpower = new FileManager() { ItemName = "Youth Empowerment.pdf", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_pdf.png", assembly) };

            var games = new FileManager() { ItemName = "Game.exe", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_exe.png", assembly) };
            var tutorials = new FileManager() { ItemName = "Tutorials.zip", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_zip.png", assembly) };
            var typeScript = new FileManager() { ItemName = "TypeScript.7z", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_zip.png", assembly) };
            var uiGuide = new FileManager() { ItemName = "UI-Guide.pdf", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_pdf.png", assembly) };

            var song = new FileManager() { ItemName = "Gouttes", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_mp3.png", assembly) };

            var camera = new FileManager() { ItemName = "Camera Roll", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_folder.png", assembly) };
            var stone = new FileManager() { ItemName = "Stone.jpg", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_png.png", assembly) };
            var wind = new FileManager() { ItemName = "Wind.jpg", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_png.png", assembly) };

            var img0 = new FileManager() { ItemName = "WIN_20160726_094117.JPG", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_img0.png", assembly) };
            var img1 = new FileManager() { ItemName = "WIN_20160726_094118.JPG", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_img1.png", assembly) };

            var video1 = new FileManager() { ItemName = "Naturals.mp4", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_video.png", assembly) };
            var video2 = new FileManager() { ItemName = "Wild.mpeg", ImageIcon = ImageSource.FromResource("MauiTreeView.Icons.treeview_video.png", assembly) };

            doc.SubFiles = new ObservableCollection<FileManager>
            {
                socialNetwork,
                youthEmpower,
                pollution,
                globalWarming,
                sanitation,
            };

            download.SubFiles = new ObservableCollection<FileManager>
            {
                games,
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.SubFiles = new ObservableCollection<FileManager>
            {
                song
            };

            pictures.SubFiles = new ObservableCollection<FileManager>
            {
                stone,
                wind,
                camera,
            };
            camera.SubFiles = new ObservableCollection<FileManager>
            {
                img0,
                img1
            };

            video.SubFiles = new ObservableCollection<FileManager>
            {
                video1,
                video2
            };


            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(video);
            nodeImageInfo.Add(doc);
            nodeImageInfo.Add(download);
            imageNodeInfo = nodeImageInfo;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}
