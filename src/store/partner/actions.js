import { api } from 'boot/axios'
/*
export function someAction (context) {
}
*/

export async function fetchAll ({ commit }) {
  const result = await api.get('/partner/all')
  if (result.status === 200) {
    commit('setAll', result.data)
  }
  return result
}

export async function create ({ commit }, data) {
  const result = await api.post('/partner', data)
  if (result.status === 201) {
    commit('add', result.data)
  }
  return result
}

export async function addCounterparty ({ commit }, data) {
  return api.post('/partner/' + data.partnerId + '/add-counterparty', JSON.stringify(data))
}

export async function getById ({ commit }, tin) {
  return api.get('/partner/' + tin)
}
