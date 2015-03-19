// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using System;
using System.ComponentModel;

using SiliconStudio.Core.Annotations;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.EntityModel;
using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;

namespace SiliconStudio.Paradox.Engine
{
    /// <summary>
    /// Describes the camera projection and view.
    /// </summary>
    [DataContract("CameraComponent")]
    [Display(130, "Camera")]
    [GizmoEntityFactory(GizmoEntityFactoryNames.CameraGizmoEntityFactoryQualifiedName)]
    [DefaultEntityComponentRenderer(typeof(CameraComponentRenderer), -1000)]
    public sealed class CameraComponent : EntityComponent
    {
        /// <summary>
        /// The property key of this component.
        /// </summary>
        public static PropertyKey<CameraComponent> Key = new PropertyKey<CameraComponent>("Key", typeof(CameraComponent));

        /// <summary>
        /// Create a new <see cref="CameraComponent"/> instance.
        /// </summary>
        public CameraComponent()
            : this(10f , 100000f)
        {
        }

        /// <summary>
        /// Create a new <see cref="CameraComponent" /> instance with the provided target, near plane and far plane.
        /// </summary>
        /// <param name="nearClipPlane">The near plane value</param>
        /// <param name="farClipPlane">The far plane value</param>
        public CameraComponent(float nearClipPlane, float farClipPlane)
        {
            Projection = CameraProjectionMode.Perspective;
            VerticalFieldOfView = 45.0f;
            OrthographicSize = 10.0f;

            // TODO: Handle Aspect ratio differently
            AspectRatio = 16f / 9f;
            NearClipPlane = nearClipPlane;
            FarClipPlane = farClipPlane;
        }

        /// <summary>
        /// Gets or sets the projection.
        /// </summary>
        /// <value>The projection.</value>
        [DataMember(0)]
        [NotNull]
        public CameraProjectionMode Projection { get; set; }

        /// <summary>
        /// Gets or sets the vertical field of view in degrees.
        /// </summary>
        /// <value>
        /// The vertical field of view.
        /// </value>
        [DataMember(5)]
        [DefaultValue(45.0f)]
        [Display("Field Of View")]
        [DataMemberRange(1.0, 179.0, 1.0, 10.0, 0)]
        public float VerticalFieldOfView { get; set; }

        /// <summary>
        /// Gets or sets the vertical field of view in degrees.
        /// </summary>
        /// <value>
        /// The vertical field of view.
        /// </value>
        [DataMember(10)]
        [DefaultValue(10.0f)]
        [Display("Orthographic Size")]
        public float OrthographicSize { get; set; }

        /// <summary>
        /// Gets or sets the near plane distance.
        /// </summary>
        /// <value>
        /// The near plane distance.
        /// </value>
        [DataMember(20)]
        [DefaultValue(10f)]
        public float NearClipPlane { get; set; }

        /// <summary>
        /// Gets or sets the far plane distance.
        /// </summary>
        /// <value>
        /// The far plane distance.
        /// </value>
        [DataMember(30)]
        [DefaultValue(100000f)]
        public float FarClipPlane { get; set; }

        /// <summary>
        /// Gets or sets the aspect ratio.
        /// </summary>
        /// <value>
        /// The aspect ratio.
        /// </value>
        [DataMemberIgnore]
        public float AspectRatio { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [auto focus].
        /// </summary>
        /// <value><c>true</c> if [auto focus]; otherwise, <c>false</c>.</value>
        [DataMemberIgnore]
        public bool AutoFocus { get; set; }

        /// <summary>
        /// Gets or sets the focus distance.
        /// </summary>
        /// <value>The focus distance.</value>
        [DataMemberIgnore]
        public float FocusDistance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use custom <see cref="ViewMatrix"/>. Default is <c>false</c>
        /// </summary>
        /// <value><c>true</c> if use custom <see cref="ViewMatrix"/>; otherwise, <c>false</c>.</value>
        [DataMemberIgnore]
        public bool UseCustomViewMatrix { get; set; }

        /// <summary>
        /// Gets or sets the local view matrix. See remarks.
        /// </summary>
        /// <value>The local view matrix.</value>
        /// <remarks>
        /// This value is updated when calling <see cref="Update"/> or is directly used when <see cref="UseCustomViewMatrix"/> is <c>true</c>.
        /// </remarks>
        [DataMemberIgnore]
        public Matrix ViewMatrix;

        /// <summary>
        /// Gets or sets a value indicating whether to use custom <see cref="ProjectionMatrix"/>. Default is <c>false</c>
        /// </summary>
        /// <value><c>true</c> if use custom <see cref="ProjectionMatrix"/>; otherwise, <c>false</c>.</value>
        [DataMemberIgnore]
        public bool UseCustomProjectionMatrix { get; set; }

        /// <summary>
        /// Gets or sets the local projection matrix. See remarks.
        /// </summary>
        /// <value>The local projection matrix.</value>
        /// <remarks>
        /// This value is updated when calling <see cref="Update"/> or is directly used when <see cref="UseCustomViewMatrix"/> is <c>true</c>.
        /// </remarks>
        [DataMemberIgnore]
        public Matrix ProjectionMatrix;

        /// <summary>
        /// The view projection matrix calculated automatically after calling <see cref="Update"/> method.
        /// </summary>
        [DataMemberIgnore]
        public Matrix ViewProjectionMatrix;

        /// <summary>
        /// Calculates the projection matrix and view matrix.
        /// </summary>
        public void Update()
        {
            // Calculates the View
            if (!UseCustomViewMatrix)
            {
                var worldMatrix = EnsureEntity.Transform.WorldMatrix;
                Matrix.Invert(ref worldMatrix, out ViewMatrix);
            }
            
            // Calculates the projection
            // TODO: Should we throw an error if Projection is not set?
            if (!UseCustomProjectionMatrix)
            {
                ProjectionMatrix = Projection == CameraProjectionMode.Perspective ? Matrix.PerspectiveFovRH(MathUtil.DegreesToRadians(VerticalFieldOfView), AspectRatio, NearClipPlane, FarClipPlane) : Matrix.OrthoRH(OrthographicSize, OrthographicSize, NearClipPlane, FarClipPlane);
            }

            // Update ViewProjectionMatrix
            Matrix.Multiply(ref ViewMatrix, ref ProjectionMatrix, out ViewProjectionMatrix);
        }

        public override PropertyKey GetDefaultKey()
        {
            return Key;
        }
    }
}