# how-to-sort-the-TreeView-node-in-SfTreeView
This repository demonstrates how to sort the treeview nodes in SfTreeView.

## Sample

### XAML

```xaml
        <Button Text="Sort TreeView" Command="{Binding TreeViewSortCommand}" HeightRequest="50" Grid.Row="0" />
        <syncfusion:SfTreeView x:Name="treeView" Grid.Row="1" ChildPropertyName="SubFiles" ItemTemplateContextType="Node" AutoExpandMode="AllNodesExpanded" ItemsSource="{Binding ImageNodeInfo}">
            <syncfusion:SfTreeView.ItemTemplate>
                <DataTemplate>
                    <Grid x:Name="grid" RowSpacing="0" >
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="40" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Image Source="{Binding Content.ImageIcon}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="35" WidthRequest="35"/>
                        <Grid Grid.Column="1" RowSpacing="1" Padding="1,0,0,0" VerticalOptions="Center">
                            <Label LineBreakMode="NoWrap" Text="{Binding Content.ItemName}" VerticalTextAlignment="Center"/>
                        </Grid>
                    </Grid>
                </DataTemplate>
            </syncfusion:SfTreeView.ItemTemplate>
        </syncfusion:SfTreeView>
```
### View Model

```csharp
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
}
```
## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements).

Make sure that you have the compatible versions of [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/ ) with the Dot NET MAUI workload and [.NET Core SDK 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) or later version in your machine before starting to work on this project.

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples. 
