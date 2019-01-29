namespace RotateMath
{
    public class Class1
    {
        private System.Drawing.Bitmap RotateMath(System.Drawing.Bitmap bmp, float angle, float current)
        {            
            float height = bmp.Height;
            float width = bmp.Width;
            int hypotenuse = System.Convert.ToInt32(System.Math.Floor(System.Math.Sqrt(height * height + width * width)));
            System.Drawing.Bitmap rotatedImage = new System.Drawing.Bitmap(hypotenuse, hypotenuse);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform((float)rotatedImage.Width / 2, (float)rotatedImage.Height / 2);
                g.RotateTransform(angle + current);
                g.TranslateTransform(-(float)rotatedImage.Width / 2, -(float)rotatedImage.Height / 2);
                g.DrawImage(bmp, (hypotenuse - width) / 2, (hypotenuse - height) / 2, width, height);
            }
            return rotatedImage;
        }
    }
}
