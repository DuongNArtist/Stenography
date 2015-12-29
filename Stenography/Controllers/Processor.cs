using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Stenography
{
    class Processor
    {
        public static string TXT = "txt";
        public static string IMG = "img";
        unsafe
        public static Bitmap ToGrayScale(Bitmap bitmap)
        {
            int step = 3;
            Rectangle bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(bounds, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            int offset = data.Stride - bitmap.Width * step;
            byte* pointer = (byte*)data.Scan0;
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    int target = (pointer[0] + pointer[1] + pointer[2]) / 3;
                    pointer[0] = (byte)target;
                    pointer[1] = (byte)target;
                    pointer[2] = (byte)target;
                    pointer += step;
                }
                pointer += offset;
            }
            bitmap.UnlockBits(data);
            return bitmap;
        }

        public static Bitmap StandardBitmapFormat(Bitmap source)
        {
            Bitmap target = new Bitmap(source.Width, source.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(target))
            {
                graphics.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height));
            }
            return target;
        }

        public static Bitmap EmbedBitmapToBitmap(Bitmap bmpSource, Bitmap bmpData, string password)
        {
            string strEmbed = GetStringFromBytes(ImageToDatabase(bmpData));
            string strData = password.PadLeft(16, ' ') + strEmbed.Length + IMG + strEmbed;
            System.Windows.Forms.MessageBox.Show(strData);
            BitArray bits = GetBitsFromString(strData);
            Bitmap target = EmbedBitsToBitmap(bmpSource, bits);
            return target;
        }

        public static Bitmap EmbedStringToBitmap(Bitmap source, string strEmbed, string password)
        {
            string strData = password.PadLeft(16, ' ') + strEmbed.Length + TXT + strEmbed;
            System.Windows.Forms.MessageBox.Show(strData);
            BitArray bits = GetBitsFromString(strData);
            Bitmap target = EmbedBitsToBitmap(source, bits);
            return target;
        }

        unsafe
        public static Bitmap EmbedBitsToBitmap(Bitmap source, BitArray bits)
        {
            int width = 0;
            int height = 0;
            byte[] bytes = GetBytesFromBitmap(source, out width, out height);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (i < bits.Length)
                {
                    if (bytes[i] % 2 == 0 && bits[i])
                    {
                        bytes[i]++;
                    }
                    else if (bytes[i] % 2 == 1 && !bits[i])
                    {
                        bytes[i]--;
                    }
                }
            }
            return GetBitmapFromBytes(bytes, source.Width, source.Height);
        }

        unsafe
        public static byte[] GetBytesFromBitmap(Bitmap bitmap, out int width, out int height)
        {
            int step = 3;
            byte[] bytes = new byte[bitmap.Width * bitmap.Height * step];
            Rectangle bounds = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData data = bitmap.LockBits(bounds, ImageLockMode.ReadOnly, bitmap.PixelFormat);
            int offset = data.Stride - bitmap.Width * step;
            byte* pointer = (byte*)data.Scan0;
            int index = 0;
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    for (int k = 0; k < step; k++)
                    {
                        bytes[index++] = pointer[k];
                    }
                    pointer += step;
                }
                pointer += offset;
            }
            bitmap.UnlockBits(data);
            width = bounds.Width;
            height = bounds.Height;
            return bytes;
        }

        unsafe
        public static Bitmap GetBitmapFromBytes(byte[] bytes, int width, int height)
        {
            int step = 3;
            int index = 0;
            Rectangle bounds = new Rectangle(0, 0, width, height);
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            BitmapData data = bitmap.LockBits(bounds, ImageLockMode.ReadWrite, bitmap.PixelFormat);
            int offset = data.Stride - bitmap.Width * step;
            byte* pointer = (byte*)data.Scan0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < step; k++)
                    {
                        pointer[k] = bytes[index++];
                    }
                    pointer += step;
                }
                pointer += offset;
            }
            bitmap.UnlockBits(data);
            return bitmap;
        }

        public static BitArray GetBitsFromBitmap(Bitmap source)
        {
            byte[] bytes = ImageToDatabase(source);
            return new BitArray(ImageToDatabase(source));
        }

        public static byte[] GetBytesFromBits(BitArray bits)
        {
            byte[] bytes = new byte[bits.Length / 8];
            bits.CopyTo(bytes, 0);
            return bytes;
        }

        public static byte[] ImageToDatabase(Image image)
        {
            /*
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, image.RawFormat);
            byte[] bytes = new byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(bytes, 0, bytes.Length);
            return bytes;
            */
            byte[] bytes = null;
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                bytes = stream.ToArray();
            }
            return bytes;
        }

        public static Image DatabaseToBitmap(byte[] bytes)
        {
            /*
            MemoryStream memoryStream = new MemoryStream(bytes);
            memoryStream.Seek(0, SeekOrigin.Begin);
            Image image = Image.FromStream(memoryStream, true, false);
            return image;
            */
            Image image = null;
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                image = Image.FromStream(stream);
            }
            return image;
        }

        public static byte[] GetBytesFromString(string source)
        {
            byte[] bytes = new byte[source.Length * sizeof(char)];
            Buffer.BlockCopy(source.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetStringFromBytes(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char) + 1];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static BitArray GetBitsFromString(string source)
        {
            return new BitArray(GetBytesFromString(source));
        }

        public static string GetEmbededStringFromBitmap(Bitmap source, string inputPassword)
        {
            byte[] bytes = GetEmbededBytesFromBitmap(source);
            string raw = GetStringFromBytes(bytes);
            //System.Windows.Forms.MessageBox.Show(raw);
            string password = raw.Substring(0, 16).Trim();
            raw = raw.Substring(16);
            //System.Windows.Forms.MessageBox.Show("password = " + password);
            if (password == inputPassword)
            {
                int index = raw.IndexOf(TXT);
                if (index != -1)
                {
                    int length = int.Parse(raw.Substring(0, index));
                    //System.Windows.Forms.MessageBox.Show("length = " + length);
                    raw = raw.Substring(index);
                    string type = raw.Substring(0, TXT.Length);
                    raw = raw.Substring(TXT.Length);
                    //System.Windows.Forms.MessageBox.Show("type = " + type);
                    if (type == TXT)
                    {
                        string data = raw.Substring(0, length);
                        return data;
                    }
                }
            }
            System.Windows.Forms.MessageBox.Show("Mật khẩu không chính xác!");
            return null;
        }

        public static Bitmap GetEmbededBitmapFromBitmap(Bitmap source, string inputPassword)
        {
            byte[] bytes = GetEmbededBytesFromBitmap(source);
            string raw = GetStringFromBytes(bytes);
            //System.Windows.Forms.MessageBox.Show(raw);
            string password = raw.Substring(0, 16).Trim();
            raw = raw.Substring(16);
            //System.Windows.Forms.MessageBox.Show("password = " + password);
            if (password == inputPassword)
            {
                int index = raw.IndexOf(IMG);
                if (index != -1)
                {
                    int length = int.Parse(raw.Substring(0, index));
                    //System.Windows.Forms.MessageBox.Show("length = " + length);
                    raw = raw.Substring(index);
                    string type = raw.Substring(0, IMG.Length);
                    raw = raw.Substring(IMG.Length);
                    //System.Windows.Forms.MessageBox.Show("type = " + type);
                    if (type == IMG)
                    {
                        string data = raw.Substring(0, length);
                        //System.Windows.Forms.MessageBox.Show("data = " + data);
                        byte[] databytes = GetBytesFromString(data);
                        return (Bitmap)DatabaseToBitmap(databytes);
                    }
                }
            }
            System.Windows.Forms.MessageBox.Show("Mật khẩu không chính xác!");
            return null;
        }

        public static byte[] GetEmbededBytesFromBitmap(Bitmap source)
        {
            int width = 0;
            int height = 0;
            byte[] bytes = GetBytesFromBitmap(source, out width, out height);
            BitArray bits = new BitArray(bytes.Length);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] % 2 == 0)
                {
                    bits[i] = false;
                }
                else
                {
                    bits[i] = true;
                }
            }
            byte[] embeded = GetBytesFromBits(bits);
            return embeded;
        }

        public static int GetMaxEmbedBit(Bitmap source)
        {
            return 3 * source.Width * source.Height;
        }

        public static string GetStringFromBitmap(Bitmap bitmap, out int width, out int height)
        {
            /*
            string bitmapString = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                byte[] bitmapBytes = memoryStream.GetBuffer();
                bitmapString = Convert.ToBase64String(bitmapBytes, Base64FormattingOptions.InsertLineBreaks);
            }
            return bitmapString;
            */
            byte[] bytes = GetBytesFromBitmap(bitmap, out width, out height);
            string str = "";
            foreach (byte abyte in bytes)
            {
                str += Convert.ToString(abyte, 2).PadLeft(8, '0');
            }
            return str;
        }

        public static Bitmap GetBitmapFromString(string str, int width, int height)
        {
            /*
            Image image = null;
            byte[] bitmapBytes = Convert.FromBase64String(bitmapString);
            using (MemoryStream memoryStream = new MemoryStream(bitmapBytes))
            {
                image = Image.FromStream(memoryStream);
            }
            return (Bitmap)image;
            */
            BitArray bits = new BitArray(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] % 2 == 0)
                {
                    bits[i] = false;
                }
                else
                {
                    bits[i] = true;
                }
            }
            byte[] bytes = ToByteArray(bits);
            Bitmap bitmap = GetBitmapFromBytes(bytes, width, height);
            return bitmap;
        }

        public static byte[] ToByteArray(BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0) numBytes++;
            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;
            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                {
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));
                }
                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }
            return bytes;
        }
    }

}
