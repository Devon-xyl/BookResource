﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAlgorithm
{
    /// <summary>
    /// 利用蒙特卡洛方法求圆周率 概念可参考http://mdsa.51cto.com/art/201509/490338.htm
    /// 本示例的几何模型是构建了一个以（0,0）为圆心，半径为1的一个圆，在其外面构建了一个以（0,0）为中心，边长为2的正方形。
    /// 蒙特卡罗算法的典型应用之一为求圆周率PI问题。
    ///思想：一个半径r=1的圆，其面积为：S=PI∗r2=PI/4
    ///一个边长r=1的正方形，其面积为：S=r2=1
    ///那么建立一个坐标系，如果均匀的向正方形内撒点，那么落入圆心在正方形中心，半径为1的圆内的点数与全部点数的比例应该为PI/4，
    ///根据概率统计的规律，只要撒的点足够多，那么便会得到圆周率PI的非常近似的值。
    /// </summary>
    public partial class ExampleMonteCarloPi : System.Web.UI.Page
    {
        private int nums = 100000;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double x, y;//随机点
            double p;//随机点落入圆中的概率
            double m;//随机点落入圆的数量
            double pi;//所有求得pi的值
            nums = int.Parse(txtNum.Text);
            Random rand = new Random();
            m = 0;
            for (int i = 0; i <= nums; i++)
            {
                //产生（-1，-1） （1,1）之间的随机点（x,y）
                x = rand.NextDouble() * 2 - 1;
                y = rand.NextDouble() * 2 - 1;
                //如果这个点坐落在圆內
                if (x * x + y * y <= 1)
                {
                    m++;
                }
                if(chkPrintPoint.Checked)
                    Response.Write(string.Format("</br>x={0},y={1}", x, y));
            }
            p = m / nums;
            pi = 4 * p;
            Response.Write("</br>落在圆区域的次数：" + m);
            Response.Write("</br>随机点落在圆区域的概率：" + p);
            Response.Write("</br>π的值为：" + pi);
        }
    }
}