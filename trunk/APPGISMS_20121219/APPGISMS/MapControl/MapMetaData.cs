using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MapControl
{
    public class Region
    {
        private string _strRegionName;
        private Color _cRegionColor;
        private List<Point> _lstReferencePoint;

        public Region()
        {
            _lstReferencePoint = new List<Point>();
        }

        public string RegionName
        {
            get { return _strRegionName; }
            set { _strRegionName = value; }
        }

        public Color RegionColor
        {
            get { return _cRegionColor; }
            set { _cRegionColor = value; }
        }

        public void AddReferencePoint(Point pReferencePoint)
        {
            if (_lstReferencePoint.Contains(pReferencePoint) == false)
                _lstReferencePoint.Add(pReferencePoint);
        }

        public List<Point> GetReferencePoints()
        {
            return _lstReferencePoint;
        }
    }

    public class City
    {
        private string _strCityName;
        private string _strCityNo;
        private double _dCityEast;
        private double _dCitySouth;
        private double _dCityWest;
        private double _dCityNorth;
        private Dictionary<string, Region> _dicRegion;
        private List<string> _lstRegionName;

        public City()
        {
            _dicRegion = new Dictionary<string, Region>();
            _lstRegionName = new List<string>();
        }

        public string CityName
        {
            get { return _strCityName; }
            set { _strCityName = value; }
        }

        public string CityNo
        {
            get { return _strCityNo; }
            set { _strCityNo = value; }
        }

        public double CityEast
        {
            get { return _dCityEast; }
            set { _dCityEast = value; }
        }

        public double CitySouth
        {
            get { return _dCitySouth; }
            set { _dCitySouth = value; }
        }

        public double CityWest
        {
            get { return _dCityWest; }
            set { _dCityWest = value; }
        }

        public double CityNorth
        {
            get { return _dCityNorth; }
            set { _dCityNorth = value; }
        }

        public void AddRegion(Region region)
        {
            if (_lstRegionName.Contains(region.RegionName))
                return;

            _dicRegion.Add(region.RegionName, region);
            _lstRegionName.Add(region.RegionName);
        }

        public Dictionary<string, Region> GetRegion()
        {
            return _dicRegion;
        }

        public List<string> GetRegionNames()
        {
            return new List<string>(_lstRegionName);
        }
    }

    public class Building
    {
        private double _dX;
        private double _dY;
        private string _strName;

        public double[] Position
        {
            get { return new double[] { _dX, _dY }; }
            set
            {
                _dX = value[0];
                _dY = value[1];
            }
        }

        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }
    }
}
