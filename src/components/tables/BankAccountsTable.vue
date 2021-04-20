<template>
  <div>
    <q-table
      title="Банковские счета"
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Банковские счета</h6>
          <q-btn @click="addBankAccount = true" v-if="!isCreation" size="sm" color="secondary" :icon="icons.mdiPlus" label="добавить счет" />
          <q-btn @click="createBankAccount = true" v-if="isCreation" size="sm" color="secondary" :icon="icons.mdiPencil" label="создать новый" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="currency" :props="props">
            {{ props.row.currency }}
          </q-td>

          <q-td key="accountNumber" :props="props">
            {{ props.row.accountNumber }}
            <q-popup-edit
              v-model="props.row.accountNumber"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.accountNumber" dense autofocus />
            </q-popup-edit>
          </q-td>

          <q-td key="bank" :props="props">
            {{ props.row.bank }}
          </q-td>

          <q-td key="bic" :props="props">
            {{ props.row.bic }}
          </q-td>

          <q-td key="company" :props="props">
            {{ props.row.company }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.tin)" :loading="loading" />
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" @click="loadBankAccount(props.row.accountNumber)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="addBankAccount" v-if="!isCreation" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Добавление банковского счета.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

    <q-dialog v-model="createBankAccount" v-if="isCreation" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6 text-primary text-bold">Создание банковского счета.</span>
        </q-card-section>

        <create-bank-account-popup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script>
import AddBankAccountPopup from 'components/addingElements/AddBankAccountPopup'
import icons from 'src/mixins/icons'
import CreateBankAccountPopup from 'components/creationElements/CreateBankAccountPopup'
export default {
  components: {
    CreateBankAccountPopup,
    AddBankAccountPopup
  },
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    },
    isCreation: {
      type: Boolean,
      default: () => true
    }
  },
  methods: {
    saveChanges (tin) {
    },
    loadBankAccount (accountNumber) {
      this.$router.push('/bank-account/' + accountNumber)
    }
  },
  data: () => {
    return {
      loading: false,
      addBankAccount: false,
      createBankAccount: false,
      columns: [
        { name: 'name', label: 'Название', align: 'left', field: 'name' },
        { name: 'currency', label: 'Валюта', field: 'currency' },
        { name: 'accountNumber', label: 'Номер счета', field: 'accountNumber' },
        { name: 'bank', label: 'Банк', field: 'bank' },
        { name: 'bic', label: 'БИК банка', field: 'bic' },
        { name: 'company', label: 'Компания', field: 'company' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
