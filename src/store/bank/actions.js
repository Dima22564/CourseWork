import { api } from 'boot/axios'

export async function create ({ commit }, data) {
  const result = await api.post('/bank', data)
  if (result.status === 201) {
    commit('add', result.data)
  }
  return result
}

export async function fetchAll ({ commit }) {
  const result = await api.get('/bank/all')
  if (result.status === 200) {
    commit('setAll', result.data)
  }
}
