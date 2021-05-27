import { api } from 'boot/axios'

/*
export function someAction (context) {
}
*/

export async function fetchAll ({ commit }) {
  const result = await api.get('/business-proposal/all')
  if (result.status === 200) {
    commit('setAll', result.data)
  }
  return result
}

export async function create ({ commit }, data) {
  const result = await api.post('/business-proposal', JSON.stringify(data))
  if (result.status === 201) {
    commit('add', result.data)
  }
  return result
}

export async function changeStatus ({ commit }, data) {
  return api.patch('/business-proposal/' + data.number + '/' + data.status)
}

export async function addProducts ({ commit, state }, number) {
  const result = await api.put('/business-proposal/' + number, JSON.stringify(state.businessProposalProducts))
  console.log(result)
  if (result.status === 201) {
    commit('add', result.data)
  }
  return result
}

export async function getById ({ commit }, tin) {
  return api.get('/counterparty/' + tin)
}
