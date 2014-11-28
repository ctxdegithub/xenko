﻿// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Paradox Shader Mixin Code Generator.
// To generate it yourself, please install SiliconStudio.Paradox.VisualStudio.Package .vsix
// and re-save the associated .pdxfx.
// </auto-generated>

using System;
using SiliconStudio.Core;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Graphics;
using SiliconStudio.Paradox.Shaders;
using SiliconStudio.Core.Mathematics;
using Buffer = SiliconStudio.Paradox.Graphics.Buffer;

using SiliconStudio.Paradox.Engine;
namespace SiliconStudio.Paradox.Effects.ShadowMaps
{
    internal static partial class ShaderMixins
    {
        internal partial class ShadowMapReceiverEffect  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
            {
                context.Mixin(mixin, "ShadowMapCascadeBase");
                mixin.Mixin.AddMacro("SHADOWMAP_COUNT", context.GetParam(ShadowMapParameters.ShadowMapCount));
                mixin.Mixin.AddMacro("SHADOWMAP_CASCADE_COUNT", context.GetParam(ShadowMapParameters.ShadowMapCascadeCount));
                if (context.GetParam(ShadowMapParameters.FilterType) == ShadowMapFilterType.Nearest)
                    context.Mixin(mixin, "ShadowMapFilterDefault");
                else if (context.GetParam(ShadowMapParameters.FilterType) == ShadowMapFilterType.PercentageCloserFiltering)
                    context.Mixin(mixin, "ShadowMapFilterPcf");
                else if (context.GetParam(ShadowMapParameters.FilterType) == ShadowMapFilterType.Variance)
                    context.Mixin(mixin, "ShadowMapFilterVsm");
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("ShadowMapReceiverEffect", new ShadowMapReceiverEffect());
            }
        }
    }
    internal static partial class ShaderMixins
    {
        internal partial class ShadowMapCaster  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
            {
                context.CloneParentMixinToCurrent();
                context.Mixin(mixin, "ShadowMapCasterBase");
                if (context.GetParam(ShadowMapParameters.FilterType) == ShadowMapFilterType.Variance)
                    context.Mixin(mixin, "ShadowMapCasterVsm");
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("ShadowMapCaster", new ShadowMapCaster());
            }
        }
    }
    internal static partial class ShaderMixins
    {
        internal partial class ShadowMapEffect  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
            {

                {
                    var __subMixin = new ShaderMixinSourceTree() { Name = "ShadowMapCaster" };
                    context.BeginChild(__subMixin);
                    context.Mixin(__subMixin, "ShadowMapCaster");
                    context.EndChild();
                }
                if (context.GetParam(ShadowMapParameters.ShadowMaps) == null || context.GetParam(ShadowMapParameters.ShadowMaps).Length == 0)
                    return;
                context.Mixin(mixin, "ShadowMapReceiver");
                foreach(var ____1 in context.GetParam(ShadowMapParameters.ShadowMaps))

                {
                    context.PushParameters(____1);

                    {
                        var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };
                        context.Mixin(__subMixin, "ShadowMapReceiverEffect");
                        mixin.Mixin.AddCompositionToArray("shadows", __subMixin.Mixin);
                    }
                    context.PopParameters();
                }
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("ShadowMapEffect", new ShadowMapEffect());
            }
        }
    }
}
