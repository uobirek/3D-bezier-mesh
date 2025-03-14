# 🎨 Bezier Surface Triangle Mesh Renderer  

A Windows Forms application that renders a **3rd-degree Bézier surface** as a **triangular mesh** with adjustable **lighting, textures, and transformations**. The project supports **interactive visualization**, real-time **rotation**, and **animation** of the light source.

---

## ✨ Features  
✅ **Bézier Surface Rendering**: Loads a 3rd-degree Bézier surface from a file and interpolates it into a **triangular mesh**  
✅ **Adjustable Triangulation**: Dynamic control of mesh resolution via a slider  
✅ **3D Transformations**: Rotation around the X and Z axes using interactive sliders  
✅ **Lighting & Shading**: 
  - Specular highlights (Phong model)  
  - Adjustable coefficients for light intensity and reflection  
✅ **Texture & Normal Mapping**:  
  - Optional texture mapping using an image  
  - Support for normal maps to enhance surface details  
✅ **Light Animation**: Simulated light movement along a spiral trajectory  
✅ **Real-time Updates**: Changes in parameters instantly affect the rendered scene  

---

## 🎮 Controls  
| Control | Function |
|---------|---------|
| **Alpha Slider** | Rotates surface around the X-axis (-45° to 45°) |
| **Beta Slider** | Rotates surface around the Z-axis (0° to 10°) |
| **Triangulation Slider** | Adjusts mesh resolution |
| **kd & ks Sliders** | Control diffuse & specular lighting intensity |
| **m Slider** | Adjusts specular reflection sharpness |
| **Light Color Picker** | Changes the light color |
| **Object Color Picker** | Changes the object's base color |
| **Texture Selection** | Loads custom texture for surface mapping |
| **Normal Map Selection** | Loads a normal map for enhanced surface detail |
| **Animation Toggle** | Starts/stops light movement |

---

## 🚀 Getting Started  
### 🛠️ Prerequisites  
- Windows OS  
- .NET Framework (Windows Forms)  

### 🏗️ Installation  
1. **Clone the repository**  
   ```bash
   git clone https://github.com/your-username/TriangleMeshRenderer.git  
   cd TriangleMeshRenderer
 2. **Open the project in Visual Studio** 
 3. **Run the application (F5)**
