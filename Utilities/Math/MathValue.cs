using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Math
{
    public class MathValue
    {
        #region Fields
        private float _min;
        private float _max;
        private float _default;
        private float _value;
        private string _friendlyName;
        private MathUnitType _unit;
        private float _step;
        #endregion

        #region Constructors
        public MathValue()
        {

        }
        public MathValue(float min, float max, float defaultValue, MathUnitType unit, string friendlyname, float step)
        {
            _min = min;
            _max = max;
            _default = defaultValue;
            _unit = unit;
            _friendlyName = friendlyname;
            _step = step;

            _value = _default;
        }
        #endregion

        #region Properties
        public MathUnitType Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        public float Min
        {
            get { return _min; }
            set { _min = value; }
        }
        public float Max
        {
            get { return _max; }
            set { _max = value; }
        }
        public float Default
        {
            get { return _default; }
            set
            {
                _default = value;
                _value = _default;
            }
        }
        public float Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string FriendlyName
        {
            get { return _friendlyName; }
            set { _friendlyName = value; }
        }
        public float Step
        {
            get { return _step; }
            set { _step = value; }
        }
        #endregion
        #region Methods
        public int Precision()
        {
            int prec = 0;
            float step = _step;
            while (step < 1)
            {
                step *= 10;
                prec++;
            }
            return prec;
        }
        #endregion
    }
}
