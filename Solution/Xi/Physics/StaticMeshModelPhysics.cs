﻿using BEPUphysics;
using BEPUphysics.DataStructures;
using BEPUphysics.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Xi
{
    /// <summary>
    /// Implement static mesh physics for a simple model.
    /// </summary>
    public class StaticMeshModelPhysics : Disposable, IModelPhysics
    {
        /// <summary>
        /// Create sphere model physics.
        /// </summary>
        /// <param name="game">The game.</param>
        /// <param name="model">The visual model.</param>
        /// <param name="position">The position of the static mesh entity.</param>
        /// <param name="mass">The physics mass.</param>
        public StaticMeshModelPhysics(XiGame game, Model model, Vector3 position, float mass)
        {
            this.game = game;
            StaticTriangleGroup.StaticTriangleGroupVertex[] vertices;
            int[] indices;
            model.GetVerticesAndIndices(out vertices, out indices);
            TriangleMesh triangleMesh = new TriangleMesh(vertices, indices);
            body = new StaticTriangleGroup(triangleMesh);
            game.SceneSpace.Add(body);
        }

        /// <summary>
        /// The friction.
        /// </summary>
        public float Friction
        {
            get { return body.Friction; }
            set { body.Friction = value; }
        }

        /// <summary>
        /// The bounciness.
        /// </summary>
        public float Bounciness
        {
            get { return body.Bounciness; }
            set { body.Bounciness = value; }
        }

        /// <summary>
        /// The collision rules.
        /// </summary>
        public EntityCollisionRules CollisionRules
        {
            get { return body.CollisionRules; }
            set { body.CollisionRules = value; }
        }

        /// <summary>
        /// The static mesh entity.
        /// </summary>
        public Entity Entity { get { return null; } }

        protected override void Dispose(bool disposing)
        {
            if (disposing) game.SceneSpace.Remove(body);
            base.Dispose(disposing);
        }

        private readonly XiGame game;
        private StaticTriangleGroup body;
    }
}
