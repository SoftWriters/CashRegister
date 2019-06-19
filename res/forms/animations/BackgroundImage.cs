//Animates a little robot on the form's background in a threded process.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CCDS.Properties;
namespace CCDS.res.forms.animations
{
    class BackgroundImage
    {
        private bool incrementAnim = true;
        List<Bitmap> bgImg = new List<Bitmap>();
        int index = 0;
        private Form form;
        public BackgroundImage(Form frm)
        {
            form = frm;
            bgImg.Add(Resources.throbber_1);
            bgImg.Add(Resources.throbber_2);
            bgImg.Add(Resources.throbber_3);
            bgImg.Add(Resources.throbber_4);
            bgImg.Add(Resources.throbber_5);
            bgImg.Add(Resources.throbber_6);
            bgImg.Add(Resources.throbber_7);
            bgImg.Add(Resources.throbber_8);
            bgImg.Add(Resources.throbber_9);
            bgImg.Add(Resources.throbber_10);
            bgImg.Add(Resources.throbber_11);
            bgImg.Add(Resources.throbber_12);
            bgImg.Add(Resources.throbber_13);
            bgImg.Add(Resources.throbber_14);
            bgImg.Add(Resources.throbber_15);
            bgImg.Add(Resources.throbber_16);
            bgImg.Add(Resources.throbber_17);
            bgImg.Add(Resources.throbber_18);
            bgImg.Add(Resources.throbber_19);
            bgImg.Add(Resources.throbber_20);
            bgImg.Add(Resources.throbber_21);
            bgImg.Add(Resources.throbber_22);
            bgImg.Add(Resources.throbber_23); // all gif's

        }
        private void AnimateBackgroundImage(object sender, EventArgs e)
        {
            form.BackgroundImage = bgImg[index];
            if ((index == 0))
            {
                incrementAnim = true;
            }
            if ((index == 22))
            {
                incrementAnim = false;
            }

            if (incrementAnim)
            {
                index++;
            }
            else
            {
                index--;
            }   //goes up, and back down... uses 1/2 the images, but still seamless
        }

        public void Animate()
        {
            var tm = new System.Windows.Forms.Timer { Interval = 33 };
            tm.Tick += new EventHandler(AnimateBackgroundImage);
            tm.Start();  //start a thread to anmate while program is running
        }
    }
}