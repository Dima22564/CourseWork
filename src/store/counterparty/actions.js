import { api } from 'boot/axios'
/*
export function someAction (context) {
}
*/

export async function fetchAll ({ commit }) {
  const result = await api.get('/counterparty/all')
  if (result.status === 200) {
    commit('setAll', result.data)
  }
  return result
}

export async function create ({ commit }, data) {
  const result = await api.post('/counterparty', data)
  if (result.status === 201) {
    commit('add', result.data)
  }
  return result
}

export async function updateContacts ({ commit }, data) {
  return api.patch('/counterparty/contacts', data)
}

export async function getById ({ commit }, tin) {
  return api.get('/counterparty/' + tin)
}
