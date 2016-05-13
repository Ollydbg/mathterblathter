using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Data;

namespace Client.Game.Data.Ascii
{
	using VecMap = Dictionary<Vector3, bool>;

	public class AsciiMeshExtractor
	{
		AsciiMap map;
		FloodFill floodFill;

		public AsciiMeshExtractor (AsciiMap map)
		{
			this.map = map;
			this.floodFill = new FloodFill(map);
		}


		public Mesh contourToMesh(List<Vector3> verts, bool floor) {
			var contourLength = verts.Count;
			//create the top surface
			var topExtrusion = extrudeContour(verts, new Vector3(0, 0, 1));
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


		public Mesh chunkToMesh(Chunk chunk) {
			var chunkSize = chunk.Count;
			var ret = new Mesh();
			CombineInstance[] combine = new CombineInstance[chunkSize];
			//create using pseudo voxels
			int i = 0;
			Vector3 origin = chunk.Origin;
			foreach( var vert in chunk ) {
				var mesh = new Mesh();
				var verts = new List<Vector3>();
				verts.Add(vert - origin);
				verts.Add(new Vector3(vert.x + 1, vert.y, vert.z) - origin);
				verts.Add(new Vector3(vert.x, vert.y+1, vert.z) - origin);
				verts.Add(new Vector3(vert.x + 1, vert.y+1, vert.z) - origin);

				//do triangles
				var tris = new int[6];
				tris[0] = 0;
				tris[1] = 2;
				tris[2] = 3;
				tris[3] = 3;
				tris[4] = 1;
				tris[5] = 0;
				mesh.SetVertices(verts);
				mesh.triangles = tris;

				combine[i].mesh = mesh;
				i++;
			}

			ret.CombineMeshes(combine, true, false);
			return ret;

		}



		List<Vector3> extrudeFront (List<Vector3> verts, float direction)
		{
			var buff = new List<Vector3> ();
			foreach (var vert in verts) {
				buff.Add (new Vector3(vert.x, vert.y + direction, vert.z));
			}
			return buff;
		}

		List<Vector3> frontFaceForChunk (Chunk chunk, int extrudeDistance)
		{
			var buffer = new VecMap();
			//the +1 is to draw the bottom of the last tile
			foreach(var vert in chunk) {
				buffer[vert] = true;
				buffer[new Vector3(vert.x + extrudeDistance, vert.y, vert.z)] = true;
				buffer[new Vector3(vert.x, vert.y - extrudeDistance, vert.z)] = true;
				buffer[new Vector3(vert.x+ extrudeDistance, vert.y - extrudeDistance, vert.z)] = true;
			}
			var ret = buffer.Keys.ToList();
			return ret;
		}

		List<Vector3> extrudeToFloor (List<Vector3> verts, float absoluteBottom)
		{
			var buff = new List<Vector3> ();
			foreach (var vert in verts) {
				buff.Add (new Vector3(vert.x, absoluteBottom, vert.z));
			}
			return buff;
		}

		List<Vector3> extrudeContour(IEnumerable<Vector3> verts, Vector3 dir) {
			var buff = new List<Vector3>();
			foreach (var vert in verts) {
				buff.Add (vert + dir);
			}

			return buff;
		}

		public List<Chunk> getChunksMatching(char matchChar) {

			var buffer = new List<Chunk>();
			var ungrouped = getAllMatching(matchChar, convertSpace:false);
			var seen = new Dictionary<Vector3, bool>();
			foreach( var vec in ungrouped) {
				//keep track of which vectors we've actually seen on this trip
				if(!seen.ContainsKey(vec)) {
					var segment = floodFill.GetRegion(matchChar, (int)vec.x, (int)vec.y);
					//add grouped vectors to seen map
					segment.ForEach(p => seen[p]=true);
					//now we have to convert space!
					buffer.Add(new Chunk(segment.Select(p => InvertAsciiSpace(p))));
				}
			}

			return buffer;
		}

		public Vector3 InvertAsciiSpace(Vector3 vec) {
			return new Vector3(vec.x, map.Height-1 -vec.y, vec.z);
		}

		//ADJUSTED GRID SPACE
		public List<Vector3> getAllMatching(char matchChar, bool convertSpace = true) {
			int mapHeight = map.Height;
			var buffer = new List<Vector3> ();
			for (var x = 0; x < map.Width; x++) {
				for (var y = 0; y < mapHeight; y++) {
					if (map [x, y] == matchChar) {
						var vect = new Vector3(x, y, 0);
						if(convertSpace) {
							buffer.Add (InvertAsciiSpace(vect));
						} else {
							buffer.Add (vect);
						}
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

		
	}
}

