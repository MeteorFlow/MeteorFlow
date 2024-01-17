import axios, { AxiosError } from "axios";
import { AppSettings } from "../models/settings";

const baseUrl = "http://localhost:5029/api/settings";

export async function getSettings() {
  try {
    const response = await axios.get<AppSettings[]>(baseUrl);
    return response.data;
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function createSettings(setting: AppSettings) {
  try {
    const response = await axios.post<AppSettings>(baseUrl, setting);
    return response.data;
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function updateSettings(setting: AppSettings[]) {
  const url = `${baseUrl}/update`;
  try {
    await axios.post(url, setting);
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function deleteSettings(id:string) {
  const url = `${baseUrl}/delete`;
  try {
    await axios.delete(url, {data: {id}});
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
  
}