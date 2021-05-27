/*
export function someMutation (state) {
}
*/

export function setAll (state, data) {
  state.bankAccounts = data
}

export function add (state, data) {
  state.bankAccounts.push(data)
}
