﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DoAnNet.UserControls
{
    public partial class UC_SanPham_item : UserControl
    {
        public UC_SanPham_item()
        {
            InitializeComponent();
        }
        #region Properties
        private string _name,_img;
        private decimal _price;

        [Category("Custom Props")]
        public string Pname
        {
            get { return _name; }
            set { _name = value; lbl.Text = value; }
        }

        [Category("Custom Props")]
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                lblGia.Text = _price.ToString("#,##0")+"đ";
            }
        }
        [Category("Custom Props")]
        public string Img
        {
            get { return _img; }
            set {
                _img = value;
                //Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
                //Console.WriteLine("path: "+path); 

                string path = @"/image/" + _img + ".jpg";
                //if(System.IO.File.Exists(path))
                //    ptb.Image = Image.FromFile(@"image/" + _img + ".jpg");
                //else
                    ptb.Image = Image.FromFile(@"image/" + _img + ".jpg");

            }
        }

        #endregion

        private void btn_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Cart.cart.Count; i++)
            {
                if (Cart.cart[i].MaSP == _img)
                {
                    Cart.cart[i].SoLuong++;
                    
                    return;
                }
            }
            Cart.cart.Add(new CartItem_DTO(_img, _name, _price));
        }
    }
}
