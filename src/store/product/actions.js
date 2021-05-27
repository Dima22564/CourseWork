import { api } from 'boot/axios'
/*
export function someAction (context) {
}
*/

export async function fetchAll ({ commit }) {
  const result = await api.get('/product/all')
  if (result.status === 200) {
    commit('setAll', result.data)
  }
  return result
}

export async function create ({ commit }, data) {
  const result = await api.post('/product', data)
  if (result.status === 201) {
    commit('add', result.data)
  }
  return result
}
