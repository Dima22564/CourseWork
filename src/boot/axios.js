import Vue from 'vue'
import axios from 'axios'

Vue.prototype.$axios = axios

const api = axios.create({ baseURL: 'http://localhost:15000/api' })
api.defaults.headers['Content-Type'] = 'application/json'
Vue.prototype.$api = api

export { axios, api }
