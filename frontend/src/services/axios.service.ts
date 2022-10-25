import { AxiosRequestConfig, AxiosResponse } from 'axios';
import {api} from "./config/axios";

export const callApi = async<T>(config: AxiosRequestConfig<unknown>): Promise<AxiosResponse<T>> => {
    return await api.request<T>(config);
};