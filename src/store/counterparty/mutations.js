/*
export function someMutation (state) {
}
*/

export function setAll (state, data) {
  state.counterparties = data
}

export function add (state, data) {
  state.counterparties.push(data)
}
