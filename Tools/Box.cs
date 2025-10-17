using Timber_and_Stone;
using UnityEngine;

namespace Blueprints.Tools
{
    public class Box : MonoBehaviour
    {
        private static ControlPlayer player;
		private Material mat;

        void Start()
        {
            player = GUIManager.getInstance().controllerObj.GetComponent<ControlPlayer>();

            mat = new Material(@"
				Shader ""Lines/Gizmo""
				{
					SubShader {
						Tags { ""Queue""=""Overlay+5000"" }
						Pass
						{
							Blend SrcAlpha OneMinusSrcAlpha
							ZWrite Off
							ZTest Always
							Cull Off
							Fog { Mode Off }
							BindChannels
							{
								Bind ""vertex"",vertex
								Bind ""color"", color
							}
						}
					}
				}");
        }

        void OnPostRender()
        {
            mat.SetPass(0);

            GL.PushMatrix();
            GL.LoadIdentity();
            GL.LoadProjectionMatrix(player.currentCamera.projectionMatrix);
            GL.MultMatrix(player.currentCamera.worldToCameraMatrix);
			{
                GL.Begin(GL.QUADS);
                GL.Color(new Color(1, 1, 1, 1));

                float o = 0.5f * ChunkManager.getInstance().voxelSize + 0.0001f;
                Vector3 p = Vector3.zero;
                p.y += ChunkManager.getInstance().voxelSize / 2;

                GL.Vertex3(p.x - o, p.y - o, p.z - o);
                GL.Vertex3(p.x - o, p.y + o, p.z - o);
                GL.Vertex3(p.x + o, p.y + o, p.z - o);
                GL.Vertex3(p.x + o, p.y - o, p.z - o);

                GL.Vertex3(p.x + o, p.y - o, p.z + o);
                GL.Vertex3(p.x + o, p.y + o, p.z + o);
                GL.Vertex3(p.x - o, p.y + o, p.z + o);
                GL.Vertex3(p.x - o, p.y - o, p.z + o);

                GL.Vertex3(p.x - o, p.y - o, p.z + o);
                GL.Vertex3(p.x - o, p.y + o, p.z + o);
                GL.Vertex3(p.x - o, p.y + o, p.z - o);
                GL.Vertex3(p.x - o, p.y - o, p.z - o);

                GL.Vertex3(p.x + o, p.y - o, p.z - o);
                GL.Vertex3(p.x + o, p.y + o, p.z - o);
                GL.Vertex3(p.x + o, p.y + o, p.z + o);
                GL.Vertex3(p.x + o, p.y - o, p.z + o);

                GL.Vertex3(p.x - o, p.y + o, p.z - o);
                GL.Vertex3(p.x - o, p.y + o, p.z + o);
                GL.Vertex3(p.x + o, p.y + o, p.z + o);
                GL.Vertex3(p.x + o, p.y + o, p.z - o);

                GL.Vertex3(p.x + o, p.y - o, p.z + o);
                GL.Vertex3(p.x + o, p.y - o, p.z - o);
                GL.Vertex3(p.x - o, p.y - o, p.z - o);
                GL.Vertex3(p.x - o, p.y - o, p.z + o);

                GL.End();
            }
            GL.PopMatrix();
        }
    }
}
