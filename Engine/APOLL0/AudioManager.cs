using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace APOLL0
{
    class AudioManager
    {
        public static void PlayFileStreamed(FileInfo AudioFile)
        {
            if (AudioFile.FullName.ToString().Contains("."))
            {
                FileStream Stream = new FileStream(AudioFile.FullName, FileMode.Open);
                //somehow feed a audio player, perhaps builtin, a small stream and every few seconds update the buffer with new data and play the data.
            }
            else
            {
                //Do something
            }
        }
    }
}
