import { Component } from '@angular/core';
import { HttpResponse } from '@angular/common/http';
import { Producto } from '../entidades/producto';
import { ProductoService } from '../servicios-backend/producto/producto.service';

@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page {

  public nombre  = ""
  public IdCategoria = ""
  public listaProducto: Producto[] = []

  constructor(private ProductoService: ProductoService) {
    this.getProductoFromBackend();
  }

  private getProductoFromBackend(){
    this.ProductoService.GetProducto().subscribe({
        next: (response: HttpResponse<any>) => {
            this.listaProducto = response.body;
            console.log(this.listaProducto)
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            //console.log('complete - this.getUsuarios()');
        },
    });
  }

  public addProducto(){
   this.AddProductoFromBackend(this.nombre, this.IdCategoria)
  }

  private AddProductoFromBackend(nombre: string, IdCategoria: string){

    var productoEntidad = new Producto();
    productoEntidad.nombre = nombre;
    productoEntidad.IdCategoria = IdCategoria;

    this.ProductoService.AddProducto(productoEntidad).subscribe({
      next: (response: HttpResponse<any>) => {
          console.log(response.body)//1
          if(response.body == 1){
              alert("Se agrego el PRODUCTO con exito :)");
              this.getProductoFromBackend();//Se actualize el listado
              this.nombre = "";
              this.IdCategoria = "";
          }else{
              alert("Al agregar el PRODUCTO fallo exito :(");
          }
      },
      error: (error: any) => {
          console.log(error);
      },
      complete: () => {
          //console.log('complete - this.AddUsuario()');
      },
  });
  }

}