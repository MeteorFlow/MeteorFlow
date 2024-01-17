import axios, { AxiosError } from "axios";
import { OrderItem, Orders, Vouchers } from "../models/orders";

const baseUrl = "http://localhost:5029/api/orders";
export async function getOrder() {
    try {
        const response = await axios.get<Orders>(baseUrl);
        return response.data;
      } catch (error) {
        if (error instanceof AxiosError) {
          console.error("Error: ", error.message);
        } else {
          console.error("Error: ", error);
        }
      }
}

export async function createOrder(order: Orders) {
    try {
      const response = await axios.post<Orders>(baseUrl, order);
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        console.error("Error: ", error.message);
      } else {
        console.error("Error: ", error);
      }
    }
}

export async function deleteOrder(id: string) {
    try {
      const response = await axios.delete<Orders>(baseUrl, {data: {id}});
      return response.data;
    } catch (error) {
      if (error instanceof AxiosError) {
        console.error("Error: ", error.message);
      } else {
        console.error("Error: ", error);
      }
    }
}

export async function updateOrder(order: Orders) {
    const url = `${baseUrl}/update`;
    try {
      await axios.post<Orders>(url, order);
    } catch (error) {
      if (error instanceof AxiosError) {
        console.error("Error: ", error.message);
      } else {
        console.error("Error: ", error);
      }
    }
}

export async function getVoucher() {
    const url = `${baseUrl}/vouchers`;
    try {
        const response = await axios.get<Vouchers>(url);
        return response.data;
      } catch (error) {
        if (error instanceof AxiosError) {
          console.error("Error: ", error.message);
        } else {
          console.error("Error: ", error);
        }
      }
}

export async function deleteVoucher(id: string) {
    const url = `${baseUrl}/vouchers`;
    try {
      await axios.delete<Vouchers>(url, {data: {id}});
    } catch (error) {
      if (error instanceof AxiosError) {
        console.error("Error: ", error.message);
      } else {
        console.error("Error: ", error);
      }
    }
}

export async function getOrderItem() {
    const url = `${baseUrl}/items`;
    try {
        const response = await axios.get<OrderItem>(url);
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

export async function deleteOrderItem(id: string) {
    const url = `${baseUrl}/items`;
    try {
      await axios.delete<OrderItem>(url, {data: {id}});
    } catch (error) {
      if (error instanceof AxiosError) {
        console.error("Error: ", error.message);
      } else {
        console.error("Error: ", error);
      }
    }
}