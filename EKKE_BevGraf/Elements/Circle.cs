﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKKE_BevGraf.Elements
{
    public class Circle
    {
		private VectorG vetor3;
		private double radius;
		private double thickness;
		

		public Circle()
			: this(VectorG.Zero,1.0)
		{
		}

		public Circle(VectorG center, double radius)
		{
			this.Center = center;
			this.Radius = radius;
			this.Thickness = 0.0;

		}

		public double Thickness
		{
			get {return thickness;}
			set {thickness = value;}
		}

        public double Radius
        {
			get { return radius; }
			set { radius = value; }
		}

		public VectorG Center
		{
			get { return vetor3; }
			set { vetor3 = value; }
		}
		public double Diameter
		{
			get { return this.Radius * 2.0; }  
		}
	}
}