export function setAll (state, data) {
  state.banks = data
}

export function updateBank (state, data) {
  const bank = state.banks.find(x => x.bic === data.bic)
  bank[data.propName] = data.val
}

export function add (state, bank) {
  state.banks.push(bank)
}
