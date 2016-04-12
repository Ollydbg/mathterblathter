using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Map.Ascii
{
	using VecMap = Dictionary<Vector3, bool>;

	public class AsciiMeshExtractor
	{
		private AsciiMap map;

		public AsciiMeshExtractor (AsciiMap map)
		{
			this.map = map;
		}


		public Mesh contourToMesh(List<Vector3> verts, bool floor) {
			var contourLength = verts.Count;
			//create the top surface
			var topExtrusion = extrudeContour(verts, new Vector3(0, 0, 4));
			List<Vector3> frontExtrusion;
			if (floor) {
				frontExtrusion = extrudeToFloor (verts, 0);
			} else {
				frontExtrusion = extrudeFront (verts, -1);
			}

			verts.AddRange (topExtrusion);
			verts.AddRange (frontExtrusion);

			List<int> triangles = new List<int> ();

			for( var vi = 0; vi < contourLength - 1; vi++ ) {
				triangles.Add (vi);
				triangles.Add (vi + contourLength);
				triangles.Add (vi+1);

				triangles.Add (vi+1);
				triangles.Add (vi+contourLength);
				triangles.Add (vi+contourLength+1);
			}

			for( var vi = 0; vi < contourLength - 1; vi++ ) {
				triangles.Add (vi + contourLength*2);
				triangles.Add (vi);
				triangles.Add (vi + contourLength*2 + 1);

				triangles.Add (vi + contourLength*2 + 1);
				triangles.Add (vi);
				triangles.Add (vi + 1);
			}


			var mesh = new Mesh ();
			mesh.SetVertices (verts);
			mesh.triangles = triangles.ToArray();
			return mesh;

		}

		List<Vector3> extrudeFront (List<Vector3> verts, float direction)
		{
			var buff = new List<Vector3> ();
			foreach (var vert in verts) {
				buff.Add (new Vector3(vert.x, vert.y + direction, vert.z));
			}
			return buff;
		}

		List<Vector3> extrudeToFloor (List<Vector3> verts, float absoluteBottom)
		{
			var buff = new List<Vector3> ();
			foreach (var vert in verts) {
				buff.Add (new Vector3(vert.x, absoluteBottom, vert.z));
			}
			return buff;
		}

		List<Vector3> extrudeContour(List<Vector3> verts, Vector3 dir) {
			var buff = new List<Vector3>();
			foreach (var vert in verts) {
				buff.Add (vert + dir);
			}

			return buff;
		}

		//ADJUSTED GRID SPACE
		public List<Vector3> getAllMatching(char matchChar) {
			int mapHeight = map.Height;
			var buffer = new List<Vector3> ();
			for (var x = 0; x < map.Width; x++) {
				for (var y = 0; y < mapHeight; y++) {
					if (map [x, y] == matchChar) {
						buffer.Add (new Vector3(x, mapHeight-1-y, 0));
					}
				}
			}
			return buffer;
		}

		//GRID SPACE
		public bool getFirstMatching(char matchChar, out int x, out int y) {
			int mapHeight = map.Height;
			for (x = 0; x < map.Width; x++) {
				for (y = 0; y < mapHeight; y++) {
					if (map [x, y] == matchChar) {
						return true;
					}
				}
			}

			x = -1;
			y = -1;
			return false;
		}

		//ghetto ass flood fill
		public List<List<Vector3>> readColumns (char matchChar)
		{
			
			List<List<Vector3>> segments = new List<List<Vector3>> ();
			List<Vector3> buffer = new List<Vector3> ();
			int mapHeight = map.Height;
			bool readingSegment = false;
			for (var x = 0; x < map.Width; x++) {
				bool matched = false;
				for (var y = 0; y < map.Height; y++) {
					if (map [x, y] == matchChar) {
						//ascii space is y-down, we need to convert to y-up
						buffer.Add (new Vector3 (x, mapHeight-y, 0));
						buffer.Add (new Vector3 (x+1, mapHeight-y, 0));
						matched = true;
						readingSegment = true;
					} 
				}


				if(readingSegment && matched) {
					segments.Add (buffer);
					readingSegment = false;
					buffer = new List<Vector3> ();
				}

			}

			//in case the search went through the whole map
			if(readingSegment) {
				segments.Add(buffer);
			}

			return segments;

		}

		//ghetto ass flood fill
		public List<List<Vector3>> readRows (char matchChar)
		{
			var ramps = getAllMatching (AsciiMap.RAMP);
			 List<List<Vector3>> segments = new List<List<Vector3>> ();
			VecMap buffer = new VecMap ();
			int mapHeight = map.Height;
			bool readingSegment = false;

			for (var x = 0; x < map.Width; x++) {
				bool matched = false;
				for (var y = 0; y < map.Height; y++) {


					if (!matched && map [x, y] == matchChar) {
						//ascii space is y-down, we need to convert to y-up
						buffer[new Vector3 (x, mapHeight-y)] =  true;
						buffer[new Vector3 (x + 1, mapHeight - y)] =true;

						matched = true;
						readingSegment = true;
					} 
				}


				if(readingSegment && !matched) {
					AdjustForRamps (buffer, ramps);
					segments.Add (buffer.Keys.ToList());
					readingSegment = false;
					buffer = new VecMap();
				}

			}

			//in case the search went through the whole map
			if(readingSegment) {
				AdjustForRamps (buffer, ramps);
				segments.Add(buffer.Keys.ToList());
			}

			return segments;

		}
			

		private void AdjustForRamps(VecMap buffer, List<Vector3> ramps) {
			foreach (var vec in ramps) {
				buffer.Remove (new Vector3 (vec.x+1, vec.y + 1));
				buffer.Remove (new Vector3 (vec.x, vec.y));
			}
		}
		
	}
}

