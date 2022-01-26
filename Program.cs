using System;
using System.Collections.Generic;

namespace BT2
{
    class Program
    {
        public static Hocvien head = null;
        static void Main(string[] args)
        {
            LinkedList DS = new LinkedList();
            NhapHV();
            InDS();
            DiemTBDK();
            DiemTBLN();
            DemNam();
            Timthongtintheomaso();
            XoaHV();
            
            sort(Search(max()),Search(min()));
            Console.WriteLine("\nLinked List after sorting");
            InDS();
        }
        static void NhapHV()
        {
            int num;
            Console.Write("So Hoc vien can nhap vao danh sach: ");
            num = int.Parse(Console.ReadLine());
            for (int i = 1; i <= num; i++)
            {
                ThemHV();
                Console.WriteLine();
            }
        }
        static void ThemHV()
        {
            Hocvien p = new Hocvien();
            Console.Write("Nhap Ma HV: ");
            p.maso = Console.ReadLine();
            if (p.maso != String.Empty)
            {
                Console.Write("Ho Ten: ");
                p.hoten = Console.ReadLine();
                Console.Write("Gioi tinh: ");
                p.gioitinh = Console.ReadLine();
                Console.Write("Diem TB: ");
                p.diemtb = float.Parse(Console.ReadLine());
            }
            if (head == null)
            {
                head = p;
                return;
            }
            p.Next = null;

            Hocvien last = head;
            while (last.Next != null)
                last = last.Next;

            last.Next = p;
            return;
        }

        static void InDS()
        {
            Hocvien p = head;
            while (p != null)
            {
                Console.Write(p.maso +" " + p.hoten + " ");
                Console.WriteLine();
                p = p.Next;
            }
            Console.WriteLine();
        }
        static void DiemTBDK()
        {
            Hocvien p = head; // Initialize current
            while (p != null)
            {
                if (p.diemtb >= 5)
                    Console.WriteLine (p.maso +" "+ p.hoten); // data found
                p = p.Next;
            }
            Console.WriteLine();
        }
        static float max()
        {
            Hocvien p = head;
            float max = float.MinValue;
            while (p != null)
            {
                if (max < p.diemtb)
                    max = p.diemtb;
                p = p.Next;
            }
            return max;
        }
        static float min()
        {
            Hocvien p = head;
            float min = float.MaxValue;

            while (head != null)
            {
                               
                if (min > p.diemtb)
                    min = p.diemtb;

                head = head.Next;
            }
            return min;
        }
        static void Search(float dk)
        {
            Hocvien p = head; // Initialize current
            while (p != null)
            {
                if (p.diemtb == dk)
                    Console.WriteLine(p.maso + " " + p.hoten); // data found
                p = p.Next;
            }
        }
        static void DiemTBLN()
        {
            Search(max());
            Console.WriteLine();
        }
        static void DemNam()
        {
            Hocvien p = head;
            int count = 0;
            while (p != null)
            {
                if(p.gioitinh=="Nam")
                count++;
                p = p.Next;
            }
            Console.WriteLine("So luong hv nam la: {0}", count);
            Console.WriteLine();
        }
        static void Timthongtintheomaso()
        {
            Console.WriteLine("Nhap ma so hoc vien can tim: ");
            string id = Console.ReadLine();
            int dem = 0;
            Hocvien p = head; // Initialize current
            while (p != null)
            {
                if (p.maso == id)
                {
                    dem++;
                    Console.WriteLine(p.hoten + " " );
                }// data found
                p = p.Next;
            }
            if (dem == 0) Console.WriteLine("Khong tim thay !");
        }
        static void Timthongtintheoten()
        {
            Console.WriteLine("Nhap hoten hoc vien can tim: ");
            string ten = Console.ReadLine();
            int dem = 0;
            Hocvien p = head; // Initialize current
            while (p != null)
            {
                if (p.hoten == ten)
                {
                    dem++;
                    Console.WriteLine(p.maso + " ");
                }// data found
                p = p.Next;
            }
            if (dem == 0) Console.WriteLine("Khong tim thay !");
        }
        static void Capnhatdiem()
        {

        }
        static void XoaHV()
        {
            Console.WriteLine("Nhap ma so Hoc vien can xoa: ");
            string key = Console.ReadLine();
            Hocvien temp = head, prev = null;

            if (temp != null &&
                temp.maso == key)
            {
                // Changed head
                head = temp.Next;
                return;
            }

            // Search for the key to be 
            // deleted, keep track of the
            // previous node as we need 
            // to change temp.next
            while (temp != null &&
                   temp.maso != key)
            {
                prev = temp;
                temp = temp.Next;
            }

            // If key was not present 
            // in linked list
            if (temp == null)
                return;

            // Unlink the node from linked list
            prev.Next = temp.Next;
        }
        // takes first and last node,
        // but do not break any links in
        // the whole linked list
        // takes first and last node,
        // but do not break any links in
        // the whole linked list
        static Hocvien paritionLast(Hocvien start, Hocvien end)
        {
            if (start == end || start == null || end == null)
                return start;

            Hocvien pivot_prev = start;
            Hocvien curr = start;
            float pivot = end.diemtb;

            // iterate till one before the end,
            // no need to iterate till the end
            // because end is pivot
            float temp;
            while (start != end)
            {

                if (start.diemtb < pivot)
                {
                    // keep tracks of last modified item
                    pivot_prev = curr;
                    temp = curr.diemtb;
                    curr.diemtb = start.diemtb;
                    start.diemtb = temp;
                    curr = curr.Next;
                }
                start = start.Next;
            }

            // swap the position of curr i.e.
            // next suitable index and pivot
            temp = curr.diemtb;
            curr.diemtb = pivot;
            end.diemtb = temp;

            // return one previous to current
            // because current is now pointing to pivot
            return pivot_prev;
        }

        static void sort(Hocvien start, Hocvien end)
        {
            if (start == end)
                return;

            // split list and partition recurse
            Hocvien pivot_prev = paritionLast(start, end);
            sort(start, pivot_prev);

            // if pivot is picked and moved to the start,
            // that means start and pivot is same
            // so pick from next of pivot
            if (pivot_prev != null && pivot_prev == start)
                sort(pivot_prev.Next, end);

            // if pivot is in between of the list,
            // start from next of pivot,
            // since we have pivot_prev, so we move two nodes
            else if (pivot_prev != null
                     && pivot_prev.Next != null)
                sort(pivot_prev.Next, end);
        }


    }
}
