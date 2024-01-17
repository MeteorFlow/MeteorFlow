import axios, { AxiosError } from "axios";
import { Account, User } from "../models/users";

const baseUrl = 'http://localhost:5029/api/users';
export async function getAcount() {
  const url = `${baseUrl}/account`;
  try {
    const response = await axios.get<Account>(url);
    return response.data;
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function signUp(account : Account) {
  const url = `${baseUrl}/signup`;
  try {
    const response = await axios.post<Account>(url, account);
    return response.data;
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function deleteAccount(id : string) {
  const url = `${baseUrl}/account`;
  try {
    const response = await axios.delete<Account>(url, {data: {id}});
    return response.data;
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function getUser() {
  try {
    const response = await axios.get<User>(baseUrl);
    return response.data;
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
  
}

export async function login (account: Account) {
  const url = `${baseUrl}/login`;
  try {
    await axios.post<Account>(url, account);
  } catch (error) {
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
}

export async function logout() {
  const url = `${baseUrl}/logout`;
  try{
    await axios.post(url);
  } catch (error){
    if (error instanceof AxiosError) {
      console.error("Error: ", error.message);
    } else {
      console.error("Error: ", error);
    }
  }
  
}