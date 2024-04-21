import { useEffect, useState } from "react";
import { Producto } from "./components/Producto.jsx";
import "./App.css";

function App() {
  const [cerveza, setCerveza] = useState([]);

  const getCervezas = async () => {
    const response = await fetch("https://localhost:7042/api/Cerveza/");
    if (response.ok) {
      const data = await response.json();
      setCerveza(data.resultado);
    }
  };
  useEffect(() => {
    getCervezas();
  }, []);
  return (
    <>
      <h1>Productos</h1>
      <div className="grid">
        {cerveza.map((item) => (
          <Producto
            key={item.idCerveza}
            nombre={item.nombre}
            urlImagen={item.urlImagen}
            precio={item.precio}
          ></Producto>
        ))}
      </div>
    </>
  );
}

export default App;
