using System;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Utils
{
	public static class SpriteColliderFactory
	{
		//my sprites have a ton of transparent space in them, this util sizes the collider to not cover the negative space.
		private static Dictionary<Sprite, Rect> Cache = new Dictionary<Sprite, Rect>();

		public static BoxCollider2D AddBoxCollider2D(GameObject go, Sprite basedOn) {

			Rect rect;
			if(!Cache.TryGetValue(basedOn, out rect)) {
				rect = DiscoverTrueBounds(basedOn);
				Cache[basedOn] = rect;
			}

			var coll = go.AddComponent<BoxCollider2D>();
			coll.offset = rect.position * .5f;
			coll.size = rect.size;

			return coll;
		}


		private static Rect DiscoverTrueBounds(Sprite sprite) {
			
			var bounds = sprite.rect;
			//scan columns left to right;

			int xMin = (int)bounds.xMin;
			int xMax = (int)bounds.xMax;
			int yMin = (int)bounds.yMin;
			int yMax = (int)bounds.yMax;

			int adjustedXMin = xMin;
			int adjustedXMax = xMax;
			int adjustedYMin = yMin;
			int adjustedYMax = yMax;

			bool hasInfo = true;
			for(int x = xMin; x < xMax; x++) {
				hasInfo = false;
				for( int y = yMin; y < yMax; y++) {
					if(sprite.texture.GetPixel(x, y).a == 1f) {
						hasInfo = true;
						break;
					}
				}

				if(hasInfo) {
					adjustedXMin = x;
					break;
				}
			}

			//scan columns right to left;
			for(int x = xMax; x > xMin; x--) {
				hasInfo = false;
				for( int y = yMin; y < yMax; y++) {
					if(sprite.texture.GetPixel(x, y).a == 1f) {
						hasInfo = true;
						break;
					}
				}

				if(hasInfo) {
					adjustedXMax = x;
					break;
				}
			}

			//scan rows top to bottom;
			for( int y = yMin; y < yMax; y++) {
				hasInfo = false;
				for(int x = xMin; x < xMax; x++) {
					if(sprite.texture.GetPixel(x, y).a == 1f) {
						hasInfo = true;
						break;
					}
				}

				if(hasInfo) {
					adjustedYMin = y;
					break;
				}
			}

			//scan rows bottom to top;
			for( int y = yMax; y < yMin; y--) {
				hasInfo = false;
				for(int x = xMin; x < xMax; x++) {
					if(sprite.texture.GetPixel(x, y).a == 1f) {
						hasInfo = true;
						break;
					}
				}

				if(hasInfo) {
					adjustedYMax = y;
					break;
				}
			}

			//normalize rect from atlas coords to local gameobject coords

			var insetX = adjustedXMin - xMin;
			var insetY = adjustedYMin - yMin;

			
			//convert from pixel space to world units
			return new Rect(
				insetX / sprite.pixelsPerUnit,
				insetY / sprite.pixelsPerUnit,
				(adjustedXMax-adjustedXMin) / sprite.pixelsPerUnit,
				(adjustedYMax - adjustedYMin) / sprite.pixelsPerUnit
			);
		}
	}



}

