using System;
using Client.Game.Actors;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.Abilities.Movement;

namespace Client.Game.Abilities.Utils
{
	public static class ProjectileUtils
	{

		public static ProjectileActor FireProjectile(this AbilityBase ability, CharacterData projectileData, Vector3 direction, float speed, AttachPoint point, Layers layer = Layers.Projectiles) {
			Vector3 adjustedDirection = AbilityUtils.AdjustWithInaccuracy(direction, ability.context);

			var projectile = ability.context.source.Game.ActorManager.Spawn<ProjectileActor>(projectileData);

			projectile.transform.position = AttachPointComponent.AttachPointPositionOnActor(point, ability.context.source);
			projectile.Point(projectile.transform.position + adjustedDirection);

			projectile.SetMovement (new Linear(projectile, adjustedDirection, speed));
			projectile.SetCollisionFilters(ability.context, FilterList.QuickFilters);
			projectile.GameObject.layer = UnityEngine.LayerMask.NameToLayer(layer.ToString());
			ability.SpawnedActors.Add(projectile);

			projectile.OnDestroyed += (Actor actor) => {
				ability.SpawnedActors.Remove(actor);
			};

			return projectile;
		}

		public static ProjectileActor FireProjectile<T>(this AbilityBase ability, CharacterData projectileData, Vector3 direction, float speed, AttachPoint point, Layers layer = Layers.Projectiles) where T : Movement.BaseMovement 
		{
			Vector3 adjustedDirection = AbilityUtils.AdjustWithInaccuracy(direction, ability.context);

			var projectile = ability.context.source.Game.ActorManager.Spawn<ProjectileActor>(projectileData);

			projectile.transform.position = AttachPointComponent.AttachPointPositionOnActor(point, ability.context.source);
			projectile.Point(projectile.transform.position + adjustedDirection);

			var movement = Activator.CreateInstance<T>();
			movement.Init(projectile, adjustedDirection, speed);
			projectile.SetMovement (movement);
			projectile.SetCollisionFilters(ability.context, FilterList.QuickFilters);
			projectile.GameObject.layer = UnityEngine.LayerMask.NameToLayer(layer.ToString());
			ability.SpawnedActors.Add(projectile);

			projectile.OnDestroyed += (Actor actor) => {
				ability.SpawnedActors.Remove(actor);
			};

			return projectile;
		}

		public static ProjectileActor FireProjectile(this AbilityBase ability, CharacterData projectileData, Movement.BaseMovement movement, AttachPoint point) {

			var projectile = ability.context.source.Game.ActorManager.Spawn<ProjectileActor>(projectileData);
			projectile.transform.position = AttachPointComponent.AttachPointPositionOnActor(point, ability.context.source);

			projectile.transform.LookAt(projectile.transform.position + movement.Heading());

			projectile.SetMovement (movement);
			projectile.SetCollisionFilters(ability.context, FilterList.QuickFilters);
			projectile.GameObject.layer = UnityEngine.LayerMask.NameToLayer(Layers.Projectiles.ToString());
			ability.SpawnedActors.Add(projectile);

			projectile.OnDestroyed += (Actor actor) => {
				ability.SpawnedActors.Remove(actor);
			};

			return projectile;
		}

	}
}

