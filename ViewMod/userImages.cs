using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using pic_viewer.Helpers;


namespace pic_viewer.ViewMod
{
    public class userImages:OnPropChanged
    {
        string fileName;
        string filePath;
        string fileSize;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public string FileSize
        {
            get { return fileSize; }
            set
            {
                fileSize = value;
                OnPropertyChanged("FileSize");
            }
        }
    }
}
