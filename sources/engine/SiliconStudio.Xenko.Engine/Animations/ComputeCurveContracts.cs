﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;

namespace SiliconStudio.Xenko.Animations
{
    #region Vector4
    /// <summary>
    /// Sampler container for Vector4 data type
    /// </summary>
    [DataContract("ComputeCurveSamplerVector4")]
    [Display("Sampler Vector4")]
    public class ComputeCurveSamplerVector4 : ComputeCurveSampler<Vector4>
    {
        public ComputeCurveSamplerVector4()
        {
            curve = new ComputeAnimationCurveVector4();
        }

        /// <inheritdoc/>
        public override void Linear(ref Vector4 value1, ref Vector4 value2, float t, out Vector4 result)
        {
            Interpolator.Vector4.Linear(ref value1, ref value2, t, out result);
        }
    }

    /// <summary>
    /// Constant vector4 value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeConstCurveVector4")]
    [Display("Constant")]
    public class ComputeConstCurveVector4 : ComputeConstCurve<Vector4> { }

    /// <summary>
    /// Constant vector4 value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeAnimationCurveVector4")]
    [Display("Animation")]
    public class ComputeAnimationCurveVector4 : ComputeAnimationCurve<Vector4>
    {
        /// <inheritdoc/>
        public override void Cubic(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, float t, out Vector4 result)
        {
            Interpolator.Vector4.Cubic(ref value1, ref value2, ref value3, ref value4, t, out result);
        }

        /// <inheritdoc/>
        public override void Linear(ref Vector4 value1, ref Vector4 value2, float t, out Vector4 result)
        {
            Interpolator.Vector4.Linear(ref value1, ref value2, t, out result);
        }
    }

    /// <summary>
    /// Binary operator vector4 value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeBinaryCurveVector4")]
    [Display("Binary Operation")]
    public class ComputeBinaryCurveVector4 : ComputeBinaryCurve<Vector4>
    {
        /// <inheritdoc/>
        protected override Vector4 Add(Vector4 a, Vector4 b)
        {
            return a + b;
        }

        /// <inheritdoc/>
        protected override Vector4 Subtract(Vector4 a, Vector4 b)
        {
            return a - b;
        }

        /// <inheritdoc/>
        protected override Vector4 Multiply(Vector4 a, Vector4 b)
        {
            return a * b;
        }
    }

    #endregion

    #region Vector3
    /// <summary>
    /// Sampler container for Vector3 data type
    /// </summary>
    [DataContract("ComputeCurveSamplerVector3")]
    [Display("Sampler Vector3")]
    public class ComputeCurveSamplerVector3 : ComputeCurveSampler<Vector3>
    {
        public ComputeCurveSamplerVector3()
        {
            curve = new ComputeAnimationCurveVector3();
        }

        /// <inheritdoc/>
        public override void Linear(ref Vector3 value1, ref Vector3 value2, float t, out Vector3 result)
        {
            Interpolator.Vector3.Linear(ref value1, ref value2, t, out result);
        }
    }

    /// <summary>
    /// Constant vector4 value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeConstCurveVector3")]
    [Display("Constant")]
    public class ComputeConstCurveVector3 : ComputeConstCurve<Vector3> { }

    /// <summary>
    /// Constant vector4 value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeAnimationCurveVector3")]
    [Display("Animation")]
    public class ComputeAnimationCurveVector3 : ComputeAnimationCurve<Vector3>
    {
        /// <inheritdoc/>
        public override void Cubic(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float t, out Vector3 result)
        {
            Interpolator.Vector3.Cubic(ref value1, ref value2, ref value3, ref value4, t, out result);
        }

        /// <inheritdoc/>
        public override void Linear(ref Vector3 value1, ref Vector3 value2, float t, out Vector3 result)
        {
            Interpolator.Vector3.Linear(ref value1, ref value2, t, out result);
        }
    }

    /// <summary>
    /// Binary operator vector4 value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeBinaryCurveVector3")]
    [Display("Binary Operation")]
    public class ComputeBinaryCurveVector3 : ComputeBinaryCurve<Vector3>
    {
        /// <inheritdoc/>
        protected override Vector3 Add(Vector3 a, Vector3 b)
        {
            return a + b;
        }

        /// <inheritdoc/>
        protected override Vector3 Subtract(Vector3 a, Vector3 b)
        {
            return a - b;
        }

        /// <inheritdoc/>
        protected override Vector3 Multiply(Vector3 a, Vector3 b)
        {
            return a * b;
        }
    }

    #endregion

    #region Float
    /// <summary>
    /// Sampler container for float data type
    /// </summary>
    [DataContract("ComputeCurveSamplerFloat")]
    [Display("Sampler Float")]
    public class ComputeCurveSamplerFloat : ComputeCurveSampler<float>
    {
        public ComputeCurveSamplerFloat()
        {
            curve = new ComputeAnimationCurveFloat();
        }

        /// <inheritdoc/>
        public override void Linear(ref float value1, ref float value2, float t, out float result)
        {
            result = value1 + (value2 - value1) * t;
        }
    }

    /// <summary>
    /// Constant float value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeConstCurveFloat")]
    [Display("Constant")]
    public class ComputeConstCurveFloat : ComputeConstCurve<float> { }

    /// <summary>
    /// Binary operator float value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeBinaryCurveFloat")]
    [Display("Binary Operation")]
    public class ComputeBinaryCurveFloat : ComputeBinaryCurve<float>
    {
        /// <inheritdoc/>
        protected override float Add(float a, float b)
        {
            return a + b;
        }

        /// <inheritdoc/>
        protected override float Subtract(float a, float b)
        {
            return a - b;
        }

        /// <inheritdoc/>
        protected override float Multiply(float a, float b)
        {
            return a*b;
        }
    }

    /// <summary>
    /// Animation of a float value for the IComputeCurve interface
    /// </summary>
    [DataContract("ComputeAnimationCurveFloat")]
    [Display("Animation")]
    public class ComputeAnimationCurveFloat : ComputeAnimationCurve<float>
    {
        /// <inheritdoc/>
        public override void Cubic(ref float value1, ref float value2, ref float value3, ref float value4, float t, out float result)
        {
            result = Interpolator.Cubic(value1, value2, value3, value4, t);
        }

        /// <inheritdoc/>
        public override void Linear(ref float value1, ref float value2, float t, out float result)
        {
            result = Interpolator.Linear(value1, value2, t);
        }
    }

    #endregion
}
