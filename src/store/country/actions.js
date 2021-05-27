import { api } from 'boot/axios'

export async function create ({ commit }, data) {
  return api.post('/country', data)
}

export async function fetchAll ({ commit }) {
  const result = await api.get('/country/all')
  if (result.status === 200) {
    commit('setAll', result.data)
  }
}

export async function update ({ commit }, data) {
  return api.patch('/country', data)
}
