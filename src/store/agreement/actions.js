import { api } from 'boot/axios'

/*
export function someAction (context) {
}
*/

export async function fetchAll ({ commit }) {
  const result = await api.get('/agreement/all')
  if (result.status === 200) {
    commit('setAll', result.data)
  }
  return result
}

export async function create ({ commit }, data) {
  const result = await api.post('/agreement', JSON.stringify(data))
  if (result.status === 201) {
    commit('add', result.data)
  }
  return result
}

export async function changeStatus ({ commit }, data) {
  return api.patch('/agreement/' + data.number + '/' + data.status)
}
