import { ShopAccount } from "./users"

export interface Products {
    id: number
    name: string
    image?: string
    description?:string
    baseUnitPrice: number
    dateCreated: Date | string
    dateModified: Date | string
    category: Category
    vendor: ShopAccount
  }

export interface Category {
    id: number
    name?: string
    description?: string
  }

  export interface Prices{
    id: number
    unitPrice: number
    product: Products
    startDate: Date | string
    endDate: Date | string
  }