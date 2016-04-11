using System;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Map.Ascii
{
	public class AsciiMapExtractor
	{
		private AsciiMap map;

		public AsciiMapExtractor (AsciiMap map)
		{
			this.map = map;
		}


		public Mesh contourToMesh(List<Vector3> verts) {
			var contourLength = verts.Count;
			//create the top surface
			var topExtrusion = extrudeContour(verts, new Vector3(0, 0, 4));
			var frontExtrusion = extrudeFrontFace (verts, -12);

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

		List<Vector3> extrudeFrontFace (List<Vector3> verts, float absoluteBottom)
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


		//ghetto ass flood fill
		public List<List<Vector3>> getContourSegments (char matchChar)
		{
			List<List<Vector3>> segments = new List<List<Vector3>> ();
			List<Vector3> buffer = new List<Vector3> ();
			int mapHeight = map.Height;
			bool readingSegment = false;
			for (var x = 0; x < map.Width; x++) {
				bool matched = false;
				for (var y = 0; y < map.Height; y++) {
					if (!matched && map [x, y] == matchChar) {
						//ascii space is y-down, we need to convert to y-up
						buffer.Add (new Vector3 (x, mapHeight-y, 0));
						matched = true;
						readingSegment = true;
					} 
				}


				if(readingSegment && !matched) {
					segments.Add (buffer);
					readingSegment = false;
					buffer = new List<Vector3> ();

				}

			}

			return segments;

		}
			
		
	}
}

