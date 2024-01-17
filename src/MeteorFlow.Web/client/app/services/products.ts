import axios, { AxiosError } from "axios";
import { Category, Prices, Products } from "../models/products";


const baseUrl = "http://localhost:5029/api/products";

export async function getProduct() {
    try {
      const response = await axios.get<Products>(baseUrl);
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        console.error("Error: ", error.message);
      } else {
        console.error("Error: ", error);
      }
    }
}

export async function createProduct(product: Products) {
    try {
      const response = await axios.post<Products>(baseUrl, product);
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        console.error("Error: ", error.message);
      } else {
        console.error("Error: ", error);
      }
    }
  }

export async function deleteProduct(id: string) {
    try {
      const response = await axios.delete<Products>(baseUrl, {data: {id}});
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        console.error("Error: ", error.message);
      } else {
        console.error("Error: ", error);
      }
    }
}

export async function updateProduct(product: Products) {
  const url = `${baseUrl}/update`;
  try {
    await axios.post<Products>(url, product);
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function getCategory() {
    const url = `${baseUrl}/categories`;
    try {
        const response = await axios.get<Category>(url);
        return response.data;
      } catch (error) {
        if (error instanceof AxiosError) {
          console.error("Error: ", error.message);
        } else {
          console.error("Error: ", error);
        }
      }
}

export async function deleteCategory(id: string) {
  const url = `${baseUrl}/update`;
  try {
    await axios.delete<Category>(url, {data: {id}});
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function getPrice() {
    const url = `${baseUrl}/prices`;
    try {
        const response = await axios.get<Prices>(url);
        return response.data;
    }
    catch (error) {
        if (error instanceof AxiosError) {
            console.error("Error: ", error.message);
          } else {
            console.error("Error: ", error);
          }
    }
}

export async function deletePrice(id: string) {
  const url = `${baseUrl}/prices`;
  try {
    await axios.delete<Prices>(url, {data: {id}});
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}