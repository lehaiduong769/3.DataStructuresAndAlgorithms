using System;
using System.Collections.Generic;
using System.Text;

namespace BT2
{
    class Hocvien
    {
        public string maso;
        public string hoten;
        public string gioitinh;
        public float diemtb;
        public Hocvien Next;
        public Hocvien()
        {
            maso = hoten = gioitinh = string.Empty;
            diemtb = default;
            Next = null;

            this.maso = maso;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.diemtb = diemtb;

        }
    }
}

