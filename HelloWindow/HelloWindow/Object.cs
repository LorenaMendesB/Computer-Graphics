using OpenTK.Graphics.OpenGL4;

namespace HelloWindow
{
    internal class Object
    {
        private const int POSITION = 0;
        private const int COLOR = 1;
        private const int UV = 2;
        private readonly int[] OFFSET = { 0, 12, 24 };
        private readonly int VERTEX_SIZE = 8 * sizeof(float);

        private int _vertexBufferObject; // Handle
        private int _vertexArrayObject;  //
        private Texture _texture;

        private float[] _data =
        {
            //    POSITIONS    /    COLORS      /   Mapa UV
            -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 1.0f, // Vértice inferior esquerdo
            0.5f, -0.5f, 0.0f, 0.0f, 0.0f, 1.0f, 1.0f, 1.0f, // Vértice inferior direito
            0.0f, 0.5f, 0.0f, 0.0f, 1.0f, 0.0f, 0.5f, 0.0f, // Superior
        };

        public void draw()
        {
            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3); // Draw Call 
        }

        public void load()
        {
            // Generate the buffer
            _vertexBufferObject = GL.GenBuffer();
            // Points to the active buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            // Insert the data into the buffer
            GL.BufferData(BufferTarget.ArrayBuffer, _data.Length * sizeof(float), _data, BufferUsageHint.StaticDraw);
            // Generate the array object buffer
            _vertexArrayObject = GL.GenVertexArray();
            // Points to the array object
            GL.BindVertexArray(_vertexArrayObject);
            // Creates an attribute pointer
            GL.VertexAttribPointer(POSITION, 3, VertexAttribPointerType.Float, false, VERTEX_SIZE, OFFSET[POSITION]);
            GL.EnableVertexAttribArray(POSITION);
            // Color
            GL.VertexAttribPointer(COLOR, 3, VertexAttribPointerType.Float, false, VERTEX_SIZE, OFFSET[COLOR]);
            GL.EnableVertexAttribArray(COLOR);
            // UV mapping
            GL.VertexAttribPointer(UV, 2, VertexAttribPointerType.Float, false, VERTEX_SIZE, OFFSET[UV]);
            GL.EnableVertexAttribArray(UV);

            _texture = Texture.LoadFromFile("Res/Test.png");
            _texture.Use(TextureUnit.Texture0);
        }
    }
}
