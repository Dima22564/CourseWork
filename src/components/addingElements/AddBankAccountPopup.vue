<template>
  <div class="q-pa-md">
    <q-form @reset="onReset" @submit="onSubmit">
      <q-select
        filled
        v-model="accounts"
        :options="bankAccounts"
        label="Выберите необходимые счета"
        multiple
        emit-value
        map-options
        use-chips
        behavior="dialog"
        option-value="accountNumber"
        option-label="accountName"
        :display-value="bankAccounts.accountName"
      >
        <template v-slot:option="{ itemProps, itemEvents, opt, selected, toggleOption }">
          <q-item
            v-bind="itemProps"
            v-on="itemEvents"
          >
            <q-item-section>
              <q-item-label>{{ opt.accountName }}</q-item-label>
              <q-item-label>{{ opt.bankName }} - {{ opt.accountNumber }}</q-item-label>
            </q-item-section>
            <q-item-section side>
              <q-toggle :value="selected" @input="toggleOption(opt)" />
            </q-item-section>
          </q-item>
        </template>
      </q-select>

      <div class="q-mt-md">
        <q-btn label="Добавить" type="submit" color="primary"/>
        <q-btn label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
export default {
  data: () => {
    return {
      accounts: [],
      options: [
        { accountNumber: 111, bankName: 'Bank', accountName: 'account' },
        { accountNumber: 222, bankName: 'Bank', accountName: 'account' },
        { accountNumber: 333, bankName: 'Bank', accountName: 'account' },
        { accountNumber: 2541265412, bankName: 'Bank', accountName: 'account' }
      ]
    }
  },
  computed: {
    bankAccounts () {
      return this.$store.state.bankAccount.bankAccounts
    }
  },
  async created () {
    try {
      await this.$store.dispatch('bankAccount/fetchAll')
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: e.response.data
      })
    }
  },
  methods: {
    onReset () {
      this.bankAccounts = []
    },
    onSubmit () {
    }
  }
}
</script>
