import { Component } from '@angular/core';
import { Producto } from '../entidades/producto';
import { HttpResponse } from '@angular/common/http';
import { ProductoService } from '../servicios-backend/producto/producto.service';
@Component({
  selector: 'app-tab3',
  templateUrl: 'tab3.page.html',
  styleUrls: ['tab3.page.scss']
})
export class Tab3Page {
  public nombre = "";
  public IdCategoria: number | undefined;

  public listaProducto: Producto[] = [];

  constructor(private productoService: ProductoService) {
    this.getProducto();
  }

  public getProducto(){
    this.productoService.GetProducto().subscribe({
      next: (response: HttpResponse<any>) => {
        this.listaProducto = response.body;
      },
      error: (error: any) => {
        console.log(error);
      }
    });
  }

  public addProducto(){
    if (this.IdCategoria !== undefined) { // Verifica si idCategoria tiene un valor antes de usarlo
      this.AddProductoBackend(this.nombre, this.IdCategoria);
    } else {
      console.log("idCategoria no tiene un valor válido.");
    }
  }

  public AddProductoBackend(nombre: string, IdCategoria: number | undefined){

    if (IdCategoria !== undefined) { // Verifica si idCategoria tiene un valor antes de usarlo
      var productoEntidad = new Producto();
      productoEntidad.nombre = nombre;
      productoEntidad.IdCategoria = IdCategoria;
    
      this.productoService.AddProducto(productoEntidad).subscribe({
        next: (response: HttpResponse<any>) => {
          console.log(response.body);
          if(response.body == 1){
            alert("Se agregó el producto con éxito :)");
            this.getProducto();
            this.nombre = "";
          } else {
            alert("Error al agregar el producto :(");
          }
        },
        error: (error: any) => {
          console.log(error);
        },
        complete: () => {
          console.log('complete - this.AddProductoBackend()');
        }
      });
    } else {
      console.log("idCategoria no tiene un valor válido.");
    }
  }
}