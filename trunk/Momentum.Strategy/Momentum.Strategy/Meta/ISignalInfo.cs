using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Momentum.Strategy.Meta
{
    public interface ISignalInfo
    {
        Color LightColor { get; set; }
        float Value { get; set; }
    }
}
