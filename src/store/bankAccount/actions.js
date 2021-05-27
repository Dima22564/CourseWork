import { api } from 'boot/axios'
/*
export function someAction (context) {
}
*/

export async function fetchAll ({ commit }) {
  const result = await api.get('/bank-account')
  if (result.status === 200) {
    commit('setAll', result.data)
  }
  return result
}

export async function create ({ commit }, data) {
  const result = await api.post('/bank-account', data)
  if (result.status === 201) {
    commit('add', result.data)
  }
  return result
}

export async function getById ({ commit }, id) {
  return api.get('/bank-account/' + id)
}
