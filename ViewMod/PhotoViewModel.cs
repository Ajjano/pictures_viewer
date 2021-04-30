using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;
using pic_viewer.Helpers;
using System.Linq;

namespace pic_viewer.ViewMod
{
    public class PhotoViewModel:OnPropChanged
    {
        private userImages selectedPhoto;

        public ObservableCollection<userImages> images { set; get; }
        public PhotoViewModel()
        {
            images = new ObservableCollection<userImages>();
        }
        public userImages SelectedPhoto
        {
            get { return selectedPhoto; }
            set
            {
                selectedPhoto = value;
                OnPropertyChanged("SelectedPhoto");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      OpenFileDialog open = new OpenFileDialog();
                      open.Filter = "Jpeg files and png|*.jpg|All files (*.*)|*.*";
                      if (open.ShowDialog() == true)
                      {
                          FileInfo file = new FileInfo(open.FileName);
                          userImages photo = new userImages { FileName = file.Name, FileSize = file.Length.ToString(), FilePath = open.FileName };
                          if (!images.Any(p => p.FileName == photo.FileName))
                          {
                              images.Add(photo);
                              SelectedPhoto = photo;
                          }
                         
                      }
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
                {
                    userImages photo = this.SelectedPhoto as userImages;
                    if (photo != null)
                    {
                        images.Remove(photo);
                    }
                }, (obj) => images.Count > 0));
            }
        }
    }
}
