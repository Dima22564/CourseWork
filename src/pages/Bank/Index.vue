<template>
  <q-page padding>
    <q-table
      title="Банки"
      :data="banks"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="tableLoading"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Банки</h6>
          <q-btn @click="createBank = true" size="sm" color="secondary" :icon="mdiPencil" label="создать банк" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
          </q-td>
          <q-td key="bic" :props="props">
            {{ props.row.bic }}
          </q-td>
          <q-td key="corrAccount" :props="props">
            {{ props.row.corrAccount }}
          </q-td>
          <q-td key="city" :props="props">
            {{ props.row.city }}
          </q-td>
          <q-td key="address" :props="props">
            {{ props.row.address }}
          </q-td>
          <q-td key="saveChanges" :props="props">
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" @click="getBank(props.row.bic)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="createBank" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ml-sm text-h6 text-primary text-bold q-pb-none">Создание банка.</span>
        </q-card-section>

        <CreateBankPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </q-page>
</template>

<script>
import { mdiPencil } from '@quasar/extras/mdi-v5'
import CreateBankPopup from 'components/creationElements/CreateBankPopup'
export default {
  name: 'PageBanksAll',
  components: {
    CreateBankPopup
  },
  methods: {
    getBank (id) {
      this.$router.push('/bank/' + id)
    }
  },
  async created () {
    if (this.$store.state.bank.banks.length === 0) {
      try {
        await this.$store.dispatch('bank/fetchAll')
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: 'Что-то пошло не так( Не удалось загрузить данные.'
        })
      } finally {
        this.tableLoading = false
      }
    }
  },
  computed: {
    banks () {
      return this.$store.state.bank.banks
    }
  },
  data: () => {
    return {
      loading: false,
      mdiPencil,
      createBank: false,
      tableLoading: true,
      columns: [
        { name: 'name', label: 'Название', align: 'left', field: 'name' },
        { name: 'bic', label: 'БИК', field: 'bic' },
        { name: 'corrAccount', label: 'Корреспонденский счет', field: 'corrAccount' },
        { name: 'city', label: 'Город', field: 'city' },
        { name: 'address', label: 'Адрес', field: 'address' },
        { name: 'saveChanges', label: 'Действия', field: 'saveChanges' }
      ]
    }
  }
}
</script>
