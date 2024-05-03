export function Producto(props) {
  const urlImagen = props.urlImagen
  return (
    <div className='producto'>
      <div className='producto-flag-contenedor'>
        <div className='producto-flag-descuento'>
          <p className='producto-flag-descuento-texto  producto-flag-descuento-color'>
            18% OFF
          </p>
        </div>
      </div>
      <a href='#'>
        <div className='producto-informacion'>
          <img
            className='producto-imagen'
            src={urlImagen}
            alt={props.nombreImagen}
          />
          <p className='producto-nombre'>{props.nombre}</p>
          <p className='producto-precio-antes'>
            Antes ${props.precio - props.precio * 0.18}
          </p>
          <p className='producto-precio-ahora'>Ahora${props.precio}</p>
        </div>
      </a>
    </div>
  )
}
